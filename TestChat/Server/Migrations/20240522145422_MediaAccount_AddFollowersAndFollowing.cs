using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestChat.Server.Migrations
{
    /// <inheritdoc />
    public partial class MediaAccount_AddFollowersAndFollowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaAccountMediaAccount",
                columns: table => new
                {
                    FollowingId = table.Column<int>(type: "int", nullable: false),
                    FolowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAccountMediaAccount", x => new { x.FollowingId, x.FolowersId });
                    table.ForeignKey(
                        name: "FK_MediaAccountMediaAccount_MediaAccounts_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaAccountMediaAccount_MediaAccounts_FolowersId",
                        column: x => x.FolowersId,
                        principalTable: "MediaAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaAccountMediaAccount_FolowersId",
                table: "MediaAccountMediaAccount",
                column: "FolowersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaAccountMediaAccount");
        }
    }
}
