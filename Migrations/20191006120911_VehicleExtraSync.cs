using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class VehicleExtraSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Livery",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Livery",
                table: "Fraktionsfahrzeug");
        }
    }
}
