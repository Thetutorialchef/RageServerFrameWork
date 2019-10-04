using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class BlendOverlayKlasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShapeThird",
                table: "CharacterBlend");

            migrationBuilder.DropColumn(
                name: "SkinThird",
                table: "CharacterBlend");

            migrationBuilder.DropColumn(
                name: "ThirdMix",
                table: "CharacterBlend");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ShapeThird",
                table: "CharacterBlend",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "SkinThird",
                table: "CharacterBlend",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<float>(
                name: "ThirdMix",
                table: "CharacterBlend",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
