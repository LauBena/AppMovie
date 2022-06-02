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

        [Display(Name = "Descipcion de la Pelicula")]
        public string? MovieDescription { get; set; }

        [Display(Name = "Fecha de Lanzamiento")]
        [DataType(DataType.Date)]
        public DateTime MovieData { get; set; }



        [Display(Name = "Seccion")]
        public int SectionID { get; set; }
        public virtual Section? Section { get; set; }


        [Display(Name = "Genero")]
        public int GenderID { get; set; }
        public virtual Gender? Gender  { get; set; }



        [Display(Name = "Productor")]
        public int ProducerID { get; set; }
        public virtual Producer? Producer { get; set; }
    }
}