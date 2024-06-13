using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaAccountFollower",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    FollowingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAccountFollower", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_MediaAccountFollower_MediaAccounts_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaAccountFollower_MediaAccounts_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaAccountFollower_FollowingId",
                table: "MediaAccountFollower",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaAccountFollower");
        }
    }
}
