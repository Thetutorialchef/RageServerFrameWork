using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Frisur2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "FrisurFarbe",
                table: "CharacterOverlay",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrisurFarbe",
                table: "CharacterOverlay");
        }
    }
}
