using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class FraktionsfahrzeugeSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Short",
                table: "Fraktionen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Short",
                table: "Fraktionen");
        }
    }
}
