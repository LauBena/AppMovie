using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovie.Migrations
{
    public partial class ReturnMovieModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnMovie_Movie_MovieID",
                table: "ReturnMovie");

            migrationBuilder.DropIndex(
                name: "IX_ReturnMovie_MovieID",
                table: "ReturnMovie");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "ReturnMovie",
                newName: "ReturnMovieDate");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "ReturnMovie",
                newName: "MovieName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnMovieDate",
                table: "ReturnMovie",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "MovieName",
                table: "ReturnMovie",
                newName: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnMovie_MovieID",
                table: "ReturnMovie",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnMovie_Movie_MovieID",
                table: "ReturnMovie",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
