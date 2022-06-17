using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMovie.Migrations
{
    public partial class RentalRentalDetailTempModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalDetailTemp",
                columns: table => new
                {
                    RentalDetailTempID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalDetailTemp", x => x.RentalDetailTempID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalDetailTemp");
        }
    }
}
