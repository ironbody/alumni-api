using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserGroupMessageSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "AvatarURL", "Bio", "FunFact", "Name" },
                values: new object[,]
                {
                    { 1, "https://temashopse.b-cdn.net/media/catalog/product/cache/cat_resized/1200/0/s/h/shrek_r_maskeraddrakt_maskeraddrakter_maskeradklader_for_man.jpg", "Shrek/Kong lover", "Loves Shrek and Kong", "Oscar" },
                    { 2, "https://preview.redd.it/ufc-fight-night-shrek-vs-adam-sandler-v0-d3r78jgnhmv91.jpg?width=512&format=pjpg&auto=webp&s=2f93c0115d58a24e638a69f0a21fc571da99ac55", "Hello I'm Simon and I love HAVREFLARN med choklad", "Cookie lover XD", "Simon" },
                    { 3, "https://pbs.twimg.com/profile_images/1342617687663521793/4lVjmcIk_400x400.jpg", "Erik aka MuminLover1337", "I LOVE MUUUUMIN!", "Erik" }
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
                table: "UserGroup",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserGroup",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserGroup",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserGroup",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
