#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMovie.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppMovie.Controllers
{
    [Authorize]
    public class ReturnsController : Controller
    {
        private readonly AppMovieContext _context;

        public ReturnsController(AppMovieContext context)
        {
            _context = context;
        }

        // GET: Returns
        public async Task<IActionResult> Index()
        {
            var appMovieContext = _context.Return.Include(r => r.Partner);
            return View(await appMovieContext.ToListAsync());
        }

        // GET: Returns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .Include(r => r.Partner)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // GET: Returns/Create
        public IActionResult Create()
        {
            ViewData["PartnerID"] = new SelectList(_context.Partner, "PartnerID", "PartnerName");
            ViewData["MovieID"] = new SelectList(_context.Movie.Where(x => x.EstaAlquilada == true), "MovieID", "MovieName"); //agregamos viewdata de Movie
            return View();
        }

        // POST: Returns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalID,RentalDate,PartnerID")] Return @return)
        {
            if (ModelState.IsValid)
            {
                using (var transaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(@return);
                    await _context.SaveChangesAsync();


                    var moviesTemp = (from a in _context.ReturnDetailTemp select a).ToList();
                    foreach (var item in moviesTemp)
                    {
                        var details = new ReturnDetail
                        {
                            ReturnID = @return.ReturnID,
                            MovieID = item.MovieID,
                            MovieName = item.MovieName
                        };
                        _context.ReturnDetail.Add(details);
                        _context.SaveChanges();
                    }

                    _context.ReturnDetailTemp.RemoveRange(moviesTemp);
                    _context.SaveChanges();

                    transaccion.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    transaccion.Rollback();
                    var error = ex;
                }
            }

            }
            ViewData["PartnerID"] = new SelectList(_context.Partner, "PartnerID", "PartnerName", @return.PartnerID);
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "MovieName");
            ViewData["MovieID"] = new SelectList(_context.Movie.Where(x => x.EstaAlquilada == true), "MovieID", "MovieName");
            return View(@return);
        }

        // GET: Returns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Return == null)
            {
                return NotFound();
            }

            var @return = await _context.Return.FindAsync(id);
            if (@return == null)
            {
                return NotFound();
            }
            ViewData["PartnerID"] = new SelectList(_context.Partner, "PartnerID", "PartnerName", @return.PartnerID);
            return View(@return);
        }

        // POST: Returns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,ReturnDate,PartnerID")] Return @return)
        {
            if (id != @return.ReturnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@return);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnExists(@return.ReturnID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartnerID"] = new SelectList(_context.Partner, "PartnerID", "PartnerName", @return.PartnerID);
            return View(@return);
        }


        // GET: Returns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .Include(r => r.Partner)
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // POST: Returns/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @return = await _context.Return.FindAsync(id);
            if(@return != null){
                _context.Return.Remove(@return);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult AddMovieReturnTemp(int MovieID) //tenemos que decirle que recibe un valor entero y pasarle el nombre del valor a agregar
        {
            var resultado = true;
            using (var transaccion = _context.Database.BeginTransaction())
            {
                try //con el try-catch evitamos que la pagina colapse
                { //se aconseja usarlo para guardado de datos
                    var movie = (from a in _context.Movie where a.MovieID  == MovieID select a).SingleOrDefault(); //creamos una variable que guarda el valor de la consulta
                    movie.EstaAlquilada = false;
                    _context.SaveChanges();

                    var movieTemp = new ReturnDetailTemp
                    {
                        MovieID = movie.MovieID,
                        MovieName = movie.MovieName
                    };
                    _context.ReturnDetailTemp.Add(movieTemp);
                    _context.SaveChanges();

                    transaccion.Commit(); //Se guardan los cambios en la base de datos
                }
                catch (System.Exception)
                {

                    transaccion.Rollback(); //si hubo error revierte los datos y no guarda nada
                    resultado = true;
                }
            }

            ViewData["MovieID"] = new SelectList(_context.Movie.Where(x => x.EstaAlquilada == true), "MovieID", "MovieName");

            return Json(resultado);
        }

        public JsonResult CancelReturn() //tenemos que decirle que recibe un valor entero y pasarle el nombre del valor a agregar
        {
            var resultado = false;
            using (var transaccion = _context.Database.BeginTransaction())
            {
                try //con el try-catch evitamos que la pagina colapse
                { //se aconseja usarlo para guardado de datos
                    var returnTemp = (from a in _context.ReturnDetailTemp select a).ToList(); //creamos una variable que guarda el valor de la consulta

                foreach(var item in returnTemp)
                {
                    var movie = (from a in _context.Movie where a.MovieID == item.MovieID select a).SingleOrDefault();
                    movie.EstaAlquilada = true;
                    _context.SaveChanges();
                }

                _context.ReturnDetailTemp.RemoveRange(returnTemp);
                _context.SaveChanges();

                    transaccion.Commit(); //Se guardan los cambios en la base de datos
                }
                catch (System.Exception)
                {

                    transaccion.Rollback(); //si hubo error revierte los datos y no guarda nada
                    resultado = true;
                }
            }

            return Json(resultado);
        }

        public JsonResult SearchMovieReturnTemp() //tenemos que decirle que recibe un valor entero y pasarle el nombre del valor a agregar
        {

            List<ReturnDetailTemp> ListadoMovieTemp = new List<ReturnDetailTemp> ();

            var returnDetailTemp = (from a in _context.ReturnDetailTemp select a).ToList();
            foreach (var item in returnDetailTemp){

                {
                    // MovieID = item.MovieID,
                    // MovieName = item.MovieName
                    ListadoMovieTemp.Add(item);
                };
                // ListadoMovieTemp.Add(mostrarMovie);
            }

            return Json(ListadoMovieTemp);
        }

        public JsonResult SearchMovieReturn(int ReturnID)
        {

            List<ReturnDetail> ListadoMovie = new List<ReturnDetail>();

            var returnDetail = (from a in _context.ReturnDetail where a.ReturnID == ReturnID select a).ToList();
            foreach (var item in returnDetail)

            {
                ListadoMovie.Add(item);
            }
            return Json(ListadoMovie);
        }

//Agregamos el QuitarMovie
        public JsonResult QuitarReturn(int MovieID)
        {
            var resultado = false;

            using (var transaccion = _context.Database.BeginTransaction())
            {
                try
                {
                    var movie = (from a in _context.Movie where a.MovieID == MovieID select a).SingleOrDefault();
                    movie.EstaAlquilada = true;
                    _context.SaveChanges();


                    var returnTemp = (from a in _context.ReturnDetailTemp where a.MovieID == MovieID select a).SingleOrDefault();
                    _context.ReturnDetailTemp.Remove(returnTemp);
                    _context.SaveChanges();

                    transaccion.Commit();
                }
                catch (System.Exception)
                {
                    transaccion.Rollback();
                    resultado = true;
                }
            }

        return Json(resultado);
        }

        private bool ReturnExists(int id)
        {
        return _context.Return.Any(e => e.ReturnID == id);
        }
    }
}
