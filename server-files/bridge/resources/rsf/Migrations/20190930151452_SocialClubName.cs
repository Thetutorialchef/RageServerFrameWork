using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class SocialClubName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Accounts",
                nullable: true);
        }
    }
}
