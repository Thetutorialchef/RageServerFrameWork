using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Kleidungskombinationen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Drawable = table.Column<int>(nullable: false),
                    Texture = table.Column<int>(nullable: false),
                    TorsoDrawable = table.Column<int>(nullable: false),
                    TorsoTexture = table.Column<int>(nullable: false),
                    UnterhemdDrawable = table.Column<int>(nullable: false),
                    UnterhemdTexture = table.Column<int>(nullable: false),
                    Geschlecht = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothes");
        }
    }
}
