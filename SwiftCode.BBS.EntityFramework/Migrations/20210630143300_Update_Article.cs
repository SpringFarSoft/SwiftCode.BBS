using Microsoft.EntityFrameworkCore.Migrations;

namespace SwiftCode.BBS.EntityFramework.Migrations
{
    public partial class Update_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_UserInfo_CreateUserInfoId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_UserInfo_UserInfoId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Question",
                newName: "CreateUserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_UserInfoId",
                table: "Question",
                newName: "IX_Question_CreateUserInfoId");

            migrationBuilder.RenameColumn(
                name: "CreateUserInfoId",
                table: "Articles",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CreateUserInfoId",
                table: "Articles",
                newName: "IX_Articles_UserInfoId");

            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_UserInfo_UserInfoId",
                table: "Articles",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_UserInfo_CreateUserInfoId",
                table: "Question",
                column: "CreateUserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_UserInfo_UserInfoId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_UserInfo_CreateUserInfoId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CreateUserInfoId",
                table: "Question",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_CreateUserInfoId",
                table: "Question",
                newName: "IX_Question_UserInfoId");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Articles",
                newName: "CreateUserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserInfoId",
                table: "Articles",
                newName: "IX_Articles_CreateUserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_UserInfo_CreateUserInfoId",
                table: "Articles",
                column: "CreateUserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_UserInfo_UserInfoId",
                table: "Question",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
