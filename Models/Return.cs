using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{

    public class Return
    {
        [Key]
        public int ReturnID { get; set; }

        [Display(Name = "Fecha de la devolucion")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Nombre de la pelicula")]
        public int MovieName { get; set; }
    }
}