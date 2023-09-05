using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialAfterNuke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AvatarURL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FunFact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectMessage_User_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DirectMessage_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

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
                name: "UserGroup",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_UserId",
                        column: x => x.UserId,
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

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ReplyToId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Post_ReplyToId",
                        column: x => x.ReplyToId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reply_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Group for people who lowes kayaking.", "Kayakers" },
                    { 2, "Group for people who want to sing kareoke.", "Kareoke Nights" },
                    { 3, "Group for people who LOVE spongebob", "Spongebob Fanatics" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AvatarURL", "Bio", "FunFact", "Name", "WorkStatus" },
                values: new object[,]
                {
                    { 1, "https://temashopse.b-cdn.net/media/catalog/product/cache/cat_resized/1200/0/s/h/shrek_r_maskeraddrakt_maskeraddrakter_maskeradklader_for_man.jpg", "Shrek/Kong lover", "Loves Shrek and Kong", "Oscar", "Rich" },
                    { 2, "https://preview.redd.it/ufc-fight-night-shrek-vs-adam-sandler-v0-d3r78jgnhmv91.jpg?width=512&format=pjpg&auto=webp&s=2f93c0115d58a24e638a69f0a21fc571da99ac55", "Hello I'm Simon and I love HAVREFLARN med choklad", "Cookie lover XD", "Simon", "YeBoi" },
                    { 3, "https://pbs.twimg.com/profile_images/1342617687663521793/4lVjmcIk_400x400.jpg", "Erik aka MuminLover1337", "I LOVE MUUUUMIN!", "Erik", "Lobster" }
                });

            migrationBuilder.InsertData(
                table: "DirectMessage",
                columns: new[] { "Id", "Body", "RecipientId", "SenderId", "SentTime" },
                values: new object[,]
                {
                    { 1, "Hello Mr.Moomin how are you?", 3, 1, new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified) },
                    { 2, "Hey, im a bit depressed. I might need a kong strong...", 1, 3, new DateTime(2023, 9, 4, 9, 4, 57, 0, DateTimeKind.Unspecified) },
                    { 3, "lol", 3, 1, new DateTime(2023, 9, 4, 9, 5, 50, 0, DateTimeKind.Unspecified) },
                    { 4, "blablabla", 2, 1, new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified) },
                    { 5, "blablabla", 3, 2, new DateTime(2023, 9, 4, 9, 4, 32, 0, DateTimeKind.Unspecified) }
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
                table: "UserGroup",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventInfo",
                columns: new[] { "Id", "End", "Location", "PostId", "Start" },
                values: new object[] { 1, new DateTime(2023, 9, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), "My place", 2, new DateTime(2023, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reply",
                columns: new[] { "Id", "Body", "CreatorId", "ReplyToId" },
                values: new object[] { 1, "I think we should have drinks and scooby snacks", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessage_RecipientId",
                table: "DirectMessage",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessage_SenderId",
                table: "DirectMessage",
                column: "SenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reply_CreatorId",
                table: "Reply",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ReplyToId",
                table: "Reply",
                column: "ReplyToId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_UserId",
                table: "UserGroup",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectMessage");

            migrationBuilder.DropTable(
                name: "EventInfo");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
