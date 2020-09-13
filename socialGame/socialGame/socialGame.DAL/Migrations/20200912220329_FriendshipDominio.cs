using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace socialGame.DAL.Migrations
{
    public partial class FriendshipDominio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    UserIdA = table.Column<Guid>(nullable: false),
                    UserIdB = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => new { x.UserIdA, x.UserIdB });
                    table.ForeignKey(
                        name: "FK_Friendship_User_UserIdA",
                        column: x => x.UserIdA,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendship_User_UserIdB",
                        column: x => x.UserIdB,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_UserIdB",
                table: "Friendship",
                column: "UserIdB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship");
        }
    }
}
