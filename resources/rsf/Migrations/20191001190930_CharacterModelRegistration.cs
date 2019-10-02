using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class CharacterModelRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Familienstand",
                table: "Characters",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Geburtsdatum",
                table: "Characters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Geburtsort",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Geschlecht",
                table: "Characters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Staatsangehoerigkeit",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Familienstand",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Geburtsdatum",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Geburtsort",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Geschlecht",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Staatsangehoerigkeit",
                table: "Characters");
        }
    }
}
