using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class CharacterDatenSchriftarten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ushort>(
                name: "Schriftart",
                table: "CharacterDaten",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schriftart",
                table: "CharacterDaten");
        }
    }
}
