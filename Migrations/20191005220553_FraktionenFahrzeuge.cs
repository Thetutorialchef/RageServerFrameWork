using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class FraktionenFahrzeuge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fraktionsfahrzeug",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FraktionenModelId = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fraktionsfahrzeug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fraktionsfahrzeug_Fraktionen_FraktionenModelId",
                        column: x => x.FraktionenModelId,
                        principalTable: "Fraktionen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fraktionskasse",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Betrag = table.Column<double>(nullable: false),
                    FraktionenModelId = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fraktionskasse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fraktionskasse_Fraktionen_FraktionenModelId",
                        column: x => x.FraktionenModelId,
                        principalTable: "Fraktionen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fraktionsraenge",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rang = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FraktionenModelId = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fraktionsraenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fraktionsraenge_Fraktionen_FraktionenModelId",
                        column: x => x.FraktionenModelId,
                        principalTable: "Fraktionen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fraktionsfahrzeug_FraktionenModelId",
                table: "Fraktionsfahrzeug",
                column: "FraktionenModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Fraktionskasse_FraktionenModelId",
                table: "Fraktionskasse",
                column: "FraktionenModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Fraktionsraenge_FraktionenModelId",
                table: "Fraktionsraenge",
                column: "FraktionenModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fraktionsfahrzeug");

            migrationBuilder.DropTable(
                name: "Fraktionskasse");

            migrationBuilder.DropTable(
                name: "Fraktionsraenge");
        }
    }
}
