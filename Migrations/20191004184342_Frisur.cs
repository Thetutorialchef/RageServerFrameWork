using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Frisur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddBodyBlemish",
                table: "CharacterOverlay");

            migrationBuilder.AddColumn<int>(
                name: "Frisur",
                table: "CharacterOverlay",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frisur",
                table: "CharacterOverlay");

            migrationBuilder.AddColumn<byte>(
                name: "AddBodyBlemish",
                table: "CharacterOverlay",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
