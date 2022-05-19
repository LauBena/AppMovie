using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models{

    public class Location
    {

    [Key]

        public int LocationID { get; set; }


        [Display(Name = "Nombre de la Localidad")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El largo maximo es de {0} caracteres.")]

        public string LocationName { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
    }
}