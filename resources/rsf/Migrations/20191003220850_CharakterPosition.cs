using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class CharakterPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PosX",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PosY",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PosZ",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotX",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotY",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "RotZ",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PosZ",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RotX",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RotY",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "RotZ",
                table: "Characters");
        }
    }
}
