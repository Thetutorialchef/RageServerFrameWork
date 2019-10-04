using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class FaceFeaturesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoseWidth",
                table: "CharacterFeatures",
                newName: "Wangenknochenhoehe");

            migrationBuilder.RenameColumn(
                name: "NoseTip",
                table: "CharacterFeatures",
                newName: "Wangenknochenbreite");

            migrationBuilder.RenameColumn(
                name: "NoseLength",
                table: "CharacterFeatures",
                newName: "Wangenbreite");

            migrationBuilder.RenameColumn(
                name: "NoseHeight",
                table: "CharacterFeatures",
                newName: "Nasenspitze");

            migrationBuilder.RenameColumn(
                name: "NoseBridgeShift",
                table: "CharacterFeatures",
                newName: "Nasenrueckenverschiebung");

            migrationBuilder.RenameColumn(
                name: "NoseBridge",
                table: "CharacterFeatures",
                newName: "Nasenruecken");

            migrationBuilder.RenameColumn(
                name: "NeckWidth",
                table: "CharacterFeatures",
                newName: "Nasenlaenge");

            migrationBuilder.RenameColumn(
                name: "Lips",
                table: "CharacterFeatures",
                newName: "Nasenhoehe");

            migrationBuilder.RenameColumn(
                name: "JawWidth",
                table: "CharacterFeatures",
                newName: "Nasenbreite");

            migrationBuilder.RenameColumn(
                name: "JawHeight",
                table: "CharacterFeatures",
                newName: "Lippen");

            migrationBuilder.RenameColumn(
                name: "Eyes",
                table: "CharacterFeatures",
                newName: "Kinnposition");

            migrationBuilder.RenameColumn(
                name: "ChinWidth",
                table: "CharacterFeatures",
                newName: "Kinnlaenge");

            migrationBuilder.RenameColumn(
                name: "ChinShape",
                table: "CharacterFeatures",
                newName: "Kinnform");

            migrationBuilder.RenameColumn(
                name: "ChinPosition",
                table: "CharacterFeatures",
                newName: "Kinnbreite");

            migrationBuilder.RenameColumn(
                name: "ChinLength",
                table: "CharacterFeatures",
                newName: "Halsbreite");

            migrationBuilder.RenameColumn(
                name: "CheeksWidth",
                table: "CharacterFeatures",
                newName: "Brauenhoehe");

            migrationBuilder.RenameColumn(
                name: "CheekboneWidth",
                table: "CharacterFeatures",
                newName: "Brauenbreite");

            migrationBuilder.RenameColumn(
                name: "CheekboneHeight",
                table: "CharacterFeatures",
                newName: "Backenhoehe");

            migrationBuilder.RenameColumn(
                name: "BrowWidth",
                table: "CharacterFeatures",
                newName: "Backenbreite");

            migrationBuilder.RenameColumn(
                name: "BrowHeight",
                table: "CharacterFeatures",
                newName: "Augen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wangenknochenhoehe",
                table: "CharacterFeatures",
                newName: "NoseWidth");

            migrationBuilder.RenameColumn(
                name: "Wangenknochenbreite",
                table: "CharacterFeatures",
                newName: "NoseTip");

            migrationBuilder.RenameColumn(
                name: "Wangenbreite",
                table: "CharacterFeatures",
                newName: "NoseLength");

            migrationBuilder.RenameColumn(
                name: "Nasenspitze",
                table: "CharacterFeatures",
                newName: "NoseHeight");

            migrationBuilder.RenameColumn(
                name: "Nasenrueckenverschiebung",
                table: "CharacterFeatures",
                newName: "NoseBridgeShift");

            migrationBuilder.RenameColumn(
                name: "Nasenruecken",
                table: "CharacterFeatures",
                newName: "NoseBridge");

            migrationBuilder.RenameColumn(
                name: "Nasenlaenge",
                table: "CharacterFeatures",
                newName: "NeckWidth");

            migrationBuilder.RenameColumn(
                name: "Nasenhoehe",
                table: "CharacterFeatures",
                newName: "Lips");

            migrationBuilder.RenameColumn(
                name: "Nasenbreite",
                table: "CharacterFeatures",
                newName: "JawWidth");

            migrationBuilder.RenameColumn(
                name: "Lippen",
                table: "CharacterFeatures",
                newName: "JawHeight");

            migrationBuilder.RenameColumn(
                name: "Kinnposition",
                table: "CharacterFeatures",
                newName: "Eyes");

            migrationBuilder.RenameColumn(
                name: "Kinnlaenge",
                table: "CharacterFeatures",
                newName: "ChinWidth");

            migrationBuilder.RenameColumn(
                name: "Kinnform",
                table: "CharacterFeatures",
                newName: "ChinShape");

            migrationBuilder.RenameColumn(
                name: "Kinnbreite",
                table: "CharacterFeatures",
                newName: "ChinPosition");

            migrationBuilder.RenameColumn(
                name: "Halsbreite",
                table: "CharacterFeatures",
                newName: "ChinLength");

            migrationBuilder.RenameColumn(
                name: "Brauenhoehe",
                table: "CharacterFeatures",
                newName: "CheeksWidth");

            migrationBuilder.RenameColumn(
                name: "Brauenbreite",
                table: "CharacterFeatures",
                newName: "CheekboneWidth");

            migrationBuilder.RenameColumn(
                name: "Backenhoehe",
                table: "CharacterFeatures",
                newName: "CheekboneHeight");

            migrationBuilder.RenameColumn(
                name: "Backenbreite",
                table: "CharacterFeatures",
                newName: "BrowWidth");

            migrationBuilder.RenameColumn(
                name: "Augen",
                table: "CharacterFeatures",
                newName: "BrowHeight");
        }
    }
}
