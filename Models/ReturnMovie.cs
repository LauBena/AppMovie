using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{

    public class ReturnMovie
    {
        [Key]
        public int ReturnMovieID { get; set; }

        [Display(Name = "Fecha de la devolucion")]
        [DataType(DataType.Date)]
        public DateTime ReturnMovieDate { get; set; }

        [Display(Name = "Nombre de la pelicula")]
        public string? MovieName { get; set; }
    }
}