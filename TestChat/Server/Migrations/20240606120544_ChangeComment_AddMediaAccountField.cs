using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeComment_AddMediaAccountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaAccountPhoto",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAccountPhoto",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");
        }
    }
}
