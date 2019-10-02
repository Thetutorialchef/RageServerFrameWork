using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class CharacterModelSchriftart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Schriftart",
                table: "Characters",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schriftart",
                table: "Characters");
        }
    }
}
