using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class BlendOverlayAusgelagert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SocialClubName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TeamSpeakUniqueId = table.Column<string>(nullable: true),
                    WhiteListed = table.Column<int>(nullable: false),
                    EndBannedTime = table.Column<DateTime>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    MaxCharacters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountModelId = table.Column<uint>(nullable: false),
                    Vorname = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nachname = table.Column<string>(type: "varchar(50)", nullable: true),
                    Geburtsdatum = table.Column<DateTime>(nullable: false),
                    Geburtsort = table.Column<string>(type: "varchar(50)", nullable: true),
                    Staatsangehoerigkeit = table.Column<string>(type: "varchar(50)", nullable: true),
                    Geschlecht = table.Column<bool>(nullable: false),
                    Familienstand = table.Column<byte>(nullable: false),
                    Schriftart = table.Column<byte>(nullable: false),
                    PosX = table.Column<float>(nullable: false),
                    PosY = table.Column<float>(nullable: false),
                    PosZ = table.Column<float>(nullable: false),
                    RotX = table.Column<float>(nullable: false),
                    RotY = table.Column<float>(nullable: false),
                    RotZ = table.Column<float>(nullable: false),
                    Dead = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    AccountBalance = table.Column<int>(nullable: false),
                    Money = table.Column<double>(nullable: false),
                    JobRank = table.Column<int>(nullable: false),
                    WJobId = table.Column<int>(nullable: false),
                    OnDuty = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    Jail = table.Column<int>(nullable: false),
                    Jailtime = table.Column<int>(nullable: false),
                    Bank = table.Column<double>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Wantedlevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Accounts_AccountModelId",
                        column: x => x.AccountModelId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterBlend",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterModelId = table.Column<uint>(nullable: false),
                    ShapeFirst = table.Column<byte>(nullable: false),
                    ShapeMix = table.Column<float>(nullable: false),
                    ShapeSecond = table.Column<byte>(nullable: false),
                    ShapeThird = table.Column<byte>(nullable: false),
                    SkinFirst = table.Column<byte>(nullable: false),
                    SkinMix = table.Column<float>(nullable: false),
                    SkinSecond = table.Column<byte>(nullable: false),
                    SkinThird = table.Column<byte>(nullable: false),
                    ThirdMix = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterBlend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterBlend_Characters_CharacterModelId",
                        column: x => x.CharacterModelId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterOverlay",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterModelId = table.Column<uint>(nullable: false),
                    Schriftart = table.Column<ushort>(nullable: false),
                    Blemish = table.Column<byte>(nullable: false),
                    BlemishPrimaryColor = table.Column<byte>(nullable: false),
                    BlemishSecondaryColor = table.Column<byte>(nullable: false),
                    BlemishOpacity = table.Column<float>(nullable: false),
                    FacialHair = table.Column<byte>(nullable: false),
                    FacialHairPrimaryColor = table.Column<byte>(nullable: false),
                    FacialHairSecondaryColor = table.Column<byte>(nullable: false),
                    FacialHairOpacity = table.Column<float>(nullable: false),
                    Eyebrows = table.Column<byte>(nullable: false),
                    EyebrowsPrimaryColor = table.Column<byte>(nullable: false),
                    EyebrowsSecondaryColor = table.Column<byte>(nullable: false),
                    EyebrowsOpacity = table.Column<float>(nullable: false),
                    Ageing = table.Column<byte>(nullable: false),
                    AgeingPrimaryColor = table.Column<byte>(nullable: false),
                    AgeingSecondaryColor = table.Column<byte>(nullable: false),
                    AgeingOpacity = table.Column<float>(nullable: false),
                    Makeup = table.Column<byte>(nullable: false),
                    MakeupPrimaryColor = table.Column<byte>(nullable: false),
                    MakeupSecondaryColor = table.Column<byte>(nullable: false),
                    MakeupOpacity = table.Column<float>(nullable: false),
                    Blush = table.Column<byte>(nullable: false),
                    BlushPrimaryColor = table.Column<byte>(nullable: false),
                    BlushSecondaryColor = table.Column<byte>(nullable: false),
                    BlushOpacity = table.Column<float>(nullable: false),
                    Complexion = table.Column<byte>(nullable: false),
                    ComplexionPrimaryColor = table.Column<byte>(nullable: false),
                    ComplexionSecondaryColor = table.Column<byte>(nullable: false),
                    ComplexionOpacity = table.Column<float>(nullable: false),
                    SunDamage = table.Column<byte>(nullable: false),
                    SunDamagePrimaryColor = table.Column<byte>(nullable: false),
                    SunDamageSecondaryColor = table.Column<byte>(nullable: false),
                    SunDamageOpacity = table.Column<float>(nullable: false),
                    Lipstick = table.Column<byte>(nullable: false),
                    LipstickPrimaryColor = table.Column<byte>(nullable: false),
                    LipstickSecondaryColor = table.Column<byte>(nullable: false),
                    LipstickOpacity = table.Column<float>(nullable: false),
                    Moles = table.Column<byte>(nullable: false),
                    MolesPrimaryColor = table.Column<byte>(nullable: false),
                    MolesSecondaryColor = table.Column<byte>(nullable: false),
                    MolesOpacity = table.Column<float>(nullable: false),
                    ChestHair = table.Column<byte>(nullable: false),
                    ChestHairPrimaryColor = table.Column<byte>(nullable: false),
                    ChestHairSecondaryColor = table.Column<byte>(nullable: false),
                    ChestHairOpacity = table.Column<float>(nullable: false),
                    BodyBlemish = table.Column<byte>(nullable: false),
                    BodyBlemishPrimaryColor = table.Column<byte>(nullable: false),
                    BodyBlemishSecondaryColor = table.Column<byte>(nullable: false),
                    BodyBlemishOpacity = table.Column<float>(nullable: false),
                    AddBodyBlemish = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterOverlay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterOverlay_Characters_CharacterModelId",
                        column: x => x.CharacterModelId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterBlend_CharacterModelId",
                table: "CharacterBlend",
                column: "CharacterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterOverlay_CharacterModelId",
                table: "CharacterOverlay",
                column: "CharacterModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountModelId",
                table: "Characters",
                column: "AccountModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterBlend");

            migrationBuilder.DropTable(
                name: "CharacterOverlay");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
