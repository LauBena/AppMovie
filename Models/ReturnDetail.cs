using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class ReturnDetail
    {
        [Key]
        public int ReturnDetailID { get; set; }


        public int ReturnMovieID { get; set; }
        public virtual ReturnMovie? ReturnMovie { get; set; }


        public int MovieID { get; set; }
        public virtual Movie? Movie { get; set; }


        [Display(Name = "Nombre de la Película")]
        public string? MovieName { get; set; }
    }
}