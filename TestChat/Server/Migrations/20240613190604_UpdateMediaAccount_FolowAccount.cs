using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMediaAccount_FolowAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaAccountFollower");

            migrationBuilder.CreateTable(
                name: "FolowAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaAccountId = table.Column<int>(type: "int", nullable: true),
                    MediaAccountId1 = table.Column<int>(type: "int", nullable: true),
                    MediaAccountId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolowAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FolowAccount_MediaAccounts_MediaAccountId",
                        column: x => x.MediaAccountId,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolowAccount_MediaAccounts_MediaAccountId1",
                        column: x => x.MediaAccountId1,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FolowAccount_MediaAccounts_MediaAccountId2",
                        column: x => x.MediaAccountId2,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FolowAccount_MediaAccountId",
                table: "FolowAccount",
                column: "MediaAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FolowAccount_MediaAccountId1",
                table: "FolowAccount",
                column: "MediaAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_FolowAccount_MediaAccountId2",
                table: "FolowAccount",
                column: "MediaAccountId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolowAccount");

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
    }
}
