using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SocialClubName = table.Column<string>(nullable: true),
                    ForumName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TeamSpeakUniqueID = table.Column<string>(nullable: true),
                    Banned = table.Column<int>(nullable: false),
                    PermBanned = table.Column<int>(nullable: false),
                    WhiteListed = table.Column<int>(nullable: false),
                    BeginBannedTime = table.Column<DateTime>(nullable: false),
                    EndBannedTime = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    MaxCharacters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VorName = table.Column<string>(nullable: true),
                    NachName = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Dead = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    AccountBalance = table.Column<int>(nullable: false),
                    Money = table.Column<double>(nullable: false),
                    JobRank = table.Column<int>(nullable: false),
                    WJobID = table.Column<int>(nullable: false),
                    onDuty = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    Jail = table.Column<int>(nullable: false),
                    Jailtime = table.Column<int>(nullable: false),
                    Bank = table.Column<double>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Wantedlevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharID);
                    table.ForeignKey(
                        name: "FK_Characters_Accounts_UserID",
                        column: x => x.UserID,
                        principalTable: "Accounts",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserID",
                table: "Characters",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
