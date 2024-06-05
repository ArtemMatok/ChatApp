using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class Comment_AddLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Comment");
        }
    }
}
