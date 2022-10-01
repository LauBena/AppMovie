using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class Return
    {
        [Key]
        public int ReturnID { get; set; }

        [Display(Name = "Fecha de Alquiler")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }


        [Display(Name = "Socio")]
        public int MovieID { get; set; }
        public virtual Movie? Movie { get; set; }

        public virtual ICollection<ReturnDetail>? ReturnDetails { get; set; }
    }
}