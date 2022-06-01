using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }


[Display(Name = "Pais")]
[Required(ErrorMessage = "Este valor es obligatorio.")]
[MaxLength(100, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? CountryName { get; set; }

        [Display(Name = "Localidad")]
        public int LocalidadID { get; set; }
        public virtual Location? Location { get; set; }
    }
}