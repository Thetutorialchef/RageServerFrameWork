using Microsoft.EntityFrameworkCore.Migrations;

namespace rsf.Migrations
{
    public partial class ForumNameEntfernt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForumName",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForumName",
                table: "Accounts",
                nullable: true);
        }
    }
}
