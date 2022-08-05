using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovie.Migrations
{
    public partial class MovieModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaAlquilada",
                table: "Movie",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaAlquilada",
                table: "Movie");
        }
    }
}
