using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovie.Migrations
{
    public partial class AgregadoIsDeletedMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movie",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movie");
        }
    }
}
