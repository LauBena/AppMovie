using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class ReturnDetailTemp
    {

        [Key]
        public int ReturnDetailTempID { get; set; }

        public int MovieID { get; set; }


        [Display(Name = "Nombre de la Película")]
        public string? MovieName { get; set; }
    }
}