using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class ReturnMovie
    {
        [Key]
        public int ReturnMovieID { get; set; }

        [Display(Name = "Fecha de Alquiler")]
        [DataType(DataType.Date)]
        public DateTime ReturnMovieDate { get; set; }


        [Display(Name = "Pelicula")]
        public int MovieID { get; set; }
        public virtual Movie? Movie{ get; set; }

        public virtual ICollection<ReturnDetail>? ReturnDetails { get; set; }
    }
}