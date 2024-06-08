using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_MediaAccounts_CommentSenderId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentSenderId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentSenderId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentSenderId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentSenderId",
                table: "Comments",
                column: "CommentSenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_MediaAccounts_CommentSenderId",
                table: "Comments",
                column: "CommentSenderId",
                principalTable: "MediaAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
