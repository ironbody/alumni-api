using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class PostSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventInfo_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Body", "CreatedDateTime", "CreatorId", "EditedDateTime", "GroupId", "Title" },
                values: new object[,]
                {
                    { 1, "So we're having a skibidi event. If anyone have any good ideas, please write them down below.", new DateTime(2023, 9, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, "Ideas for the skibidi event" },
                    { 2, "Kräftskiva at my place, BYOB", new DateTime(2023, 9, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2, "Kräftskiva" },
                    { 3, "Wow this post is edited. Isn't that crazy?", new DateTime(2023, 9, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 9, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, "I love editing posts" }
                });

            migrationBuilder.InsertData(
                table: "EventInfo",
                columns: new[] { "Id", "End", "Location", "PostId", "Start" },
                values: new object[] { 1, new DateTime(2023, 9, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), "My place", 2, new DateTime(2023, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_EventInfo_PostId",
                table: "EventInfo",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_CreatorId",
                table: "Post",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupId",
                table: "Post",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventInfo");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
