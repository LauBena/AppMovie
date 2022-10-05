using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMovie.Models;

namespace AppMovie.Controllers
{
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


                    var moviesTemp = (from a in _context.RentalDetailTemp select a).ToList();
                    foreach (var item in moviesTemp)
                    {
                        var details = new RentalDetail
                        {
                            RentalID = @return.ReturnID,
                            MovieID = item.MovieID,
                            MovieName = item.MovieName
                        };
                        _context.RentalDetail.Add(details);
                        _context.SaveChanges();
                    }

                    _context.RentalDetailTemp.RemoveRange(moviesTemp);
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
            ViewData["MovieID"] = new SelectList(_context.Movie.Where(x => x.EstaAlquilada == false), "MovieID", "MovieName");
            return View(@return);
        }

        // GET: Returns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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
                _context.Return.Remove(@return);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult AddMovieTemp(int MovieID) //tenemos que decirle que recibe un valor entero y pasarle el nombre del valor a agregar
        {
            var resultado = true;
            using (var transaccion = _context.Database.BeginTransaction())
            {
                try //con el try-catch evitamos que la pagina colapse
                { //se aconseja usarlo para guardado de datos
                    var movie = (from a in _context.Movie where a.MovieID  == MovieID select a).SingleOrDefault(); //creamos una variable que guarda el valor de la consulta
                    movie.EstaAlquilada = true;
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
                    resultado = false;
                }
            }

            ViewData["MovieID"] = new SelectList(_context.Movie.Where(x => x.EstaAlquilada == false), "MovieID", "MovieName");

            return Json(resultado);
        }

        private bool ReturnExists(int id)
        {
          return (_context.Return?.Any(e => e.ReturnID == id)).GetValueOrDefault();
        }
    }
}
