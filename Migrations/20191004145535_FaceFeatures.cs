using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class FaceFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterFeatures",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterModelId = table.Column<uint>(nullable: false),
                    NoseWidth = table.Column<float>(nullable: false),
                    NoseHeight = table.Column<float>(nullable: false),
                    NoseLength = table.Column<float>(nullable: false),
                    NoseBridge = table.Column<float>(nullable: false),
                    NoseTip = table.Column<float>(nullable: false),
                    NoseBridgeShift = table.Column<float>(nullable: false),
                    BrowHeight = table.Column<float>(nullable: false),
                    BrowWidth = table.Column<float>(nullable: false),
                    CheekboneHeight = table.Column<float>(nullable: false),
                    CheekboneWidth = table.Column<float>(nullable: false),
                    CheeksWidth = table.Column<float>(nullable: false),
                    Eyes = table.Column<float>(nullable: false),
                    Lips = table.Column<float>(nullable: false),
                    JawWidth = table.Column<float>(nullable: false),
                    JawHeight = table.Column<float>(nullable: false),
                    ChinLength = table.Column<float>(nullable: false),
                    ChinPosition = table.Column<float>(nullable: false),
                    ChinWidth = table.Column<float>(nullable: false),
                    ChinShape = table.Column<float>(nullable: false),
                    NeckWidth = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFeatures_Characters_CharacterModelId",
                        column: x => x.CharacterModelId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFeatures_CharacterModelId",
                table: "CharacterFeatures",
                column: "CharacterModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFeatures");
        }
    }
}
