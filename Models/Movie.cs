using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }


        [Display(Name = "Nombre de la Pelicula")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? MovieName { get; set; }

        [Display(Name = "Descipción de la Película")]
        public string? MovieDescription { get; set; }

        [Display(Name = "Fecha de Lanzamiento")]
        [DataType(DataType.Date)]
        public DateTime MovieData { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Sección")]
        public int SectionID { get; set; }

        [Display(Name = "Sección")]
        public virtual Section? Section { get; set; }


        [Display(Name = "Género")]
        public int GenderID { get; set; }

        [Display(Name = "Género")]
        public virtual Gender? Gender  { get; set; }



        [Display(Name = "Productor")]
        public int ProducerID { get; set; }

        [Display(Name = "Productor")]
        public virtual Producer? Producer { get; set; }

        public bool EstaAlquilada { get; set; }
    }
}