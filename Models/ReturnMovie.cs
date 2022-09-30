using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class ReturnMovie
    {
        [Key]
        public int ReturnMovieID { get; set; }

        [Display(Name = "Fecha de la devolución")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Nombre de la película")]
        public int MovieID { get; set; }

        public virtual Movie? Movie { get; set; }
    }
}