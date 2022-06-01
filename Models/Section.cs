using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class Section
    { //public dice que nosotros desde cualquier parte de la aplicacion podemos acceder al codigo de esta clase.
    // si usaramos private en lugar de public, hacemos que sea visible solo dentro de este archivo.
    //protected solo visible para la carpeta que lo contiene.
    [Key]
        public int SectionID { get; set; } //sectionID: identifica un objeto unico. con esto nos damos cuenta rapido cuando cometemos un herror


        [Display(Name = "Nombre de la Seccion")]
        [Required(ErrorMessage = "Este valor es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El largo maximo es de {0} caracteres.")]
        public string? SectionName { get; set; }
    }
}
//instalamos mediante terminal: dotnet tool install --global dotnet-aspnet-codegenerator
//instalamos mediante terminal: dotnet tool install --global dotnet-ef
//instalamos mediante terminal: dotnet add package Microsoft.EntityFrameworkCore.Design
//instalamos mediante terminal:dotnet add package Microsoft.EntityFrameworkCore.SQLite
//instalamos mediante terminal: dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
//instalamos mediante terminal: dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//instalamos mediante terminal: dotnet-aspnet-codegenerator controller -name SectionsController -m Section -dc AppMovieContext --relativeFolderPath Controllers
//migracion inicial: para poder ejecutar mi aplicacion, debo ejecutar antes la migracion.