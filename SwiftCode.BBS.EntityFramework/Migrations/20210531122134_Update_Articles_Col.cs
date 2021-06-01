using Microsoft.EntityFrameworkCore.Migrations;

namespace SwiftCode.BBS.EntityFramework.Migrations
{
    public partial class Update_Articles_Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Articles");
        }
    }
}
