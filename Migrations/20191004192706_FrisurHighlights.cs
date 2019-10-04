using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class FrisurHighlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "FrisurHighlights",
                table: "CharacterOverlay",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrisurHighlights",
                table: "CharacterOverlay");
        }
    }
}
