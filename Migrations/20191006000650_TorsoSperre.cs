using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class TorsoSperre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Betrag",
                table: "Fraktionsraenge",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "BlinkerL",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BlinkerR",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<uint>(
                name: "Dimension",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<bool>(
                name: "Engine",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Fraktionsfahrzeug",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberPlate",
                table: "Fraktionsfahrzeug",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PosX",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PosY",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PosZ",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryColor",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "RotX",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotY",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotZ",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryColor",
                table: "Fraktionsfahrzeug",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Betrag",
                table: "Fraktionsraenge");

            migrationBuilder.DropColumn(
                name: "BlinkerL",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "BlinkerR",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "NumberPlate",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "PosZ",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "RotX",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "RotY",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "RotZ",
                table: "Fraktionsfahrzeug");

            migrationBuilder.DropColumn(
                name: "SecondaryColor",
                table: "Fraktionsfahrzeug");
        }
    }
}
