using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class SwfSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "Hello Erik, how did you eat soo many pieces in one sitting???");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "It was easy, I just did it.");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Body",
                value: "Wow, very cool!");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "Hello Simon, how are you?");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 5,
                column: "Body",
                value: "Hey Oscar! Good, I just ate 10 havreflarn!");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "Description", "Name" },
                values: new object[] { 2, "Group for people who want to sing karaoke.", "Karaoke Nights" });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Title" },
                values: new object[] { "So we're having a event. If anyone have any good ideas, please write them down below.", "The anything event" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Kräftskiva at my place.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://images.freeimages.com/images/large-previews/10e/halloween-skull-1-1309392.jpg", "Studied a game programming at BTH.", "I Have watched all shrek movies 10 times", "Employed" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://media.istockphoto.com/id/144219155/sv/foto/close-up-of-a-green-tree-frog-on-a-white-background.jpg?s=2048x2048&w=is&k=20&c=HB7twSjmtufkzMGJ1PvJ7YluR9oN7ZhD2wZQM1NMljU=", "Studied Software Engineering at BTH", "I Love Chokladdoppade havreflarn.", "Employed" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://media.istockphoto.com/id/1444396028/sv/foto/aland-islands-flag-pinned-white-background.jpg?s=2048x2048&w=is&k=20&c=PB9wGjejrjQeUonzDboZxRUrLuX9xp318lbyo_19vvI=", "Studied web development at BTH", "I Can eat 19.61 sushi pieces in one sitting.", "Employed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Body",
                value: "Hello Mr.Moomin how are you?");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Hey, im a bit depressed. I might need a kong strong...");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Body",
                value: "lol");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "blablabla");

            migrationBuilder.UpdateData(
                table: "DirectMessage",
                keyColumn: "Id",
                keyValue: 5,
                column: "Body",
                value: "blablabla");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatorId", "Description", "Name" },
                values: new object[] { 0, "Group for people who want to sing kareoke.", "Kareoke Nights" });

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatorId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Title" },
                values: new object[] { "So we're having a skibidi event. If anyone have any good ideas, please write them down below.", "Ideas for the skibidi event" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "Kräftskiva at my place, BYOB");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://temashopse.b-cdn.net/media/catalog/product/cache/cat_resized/1200/0/s/h/shrek_r_maskeraddrakt_maskeraddrakter_maskeradklader_for_man.jpg", "Shrek/Kong lover", "Loves Shrek and Kong", "Rich" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://preview.redd.it/ufc-fight-night-shrek-vs-adam-sandler-v0-d3r78jgnhmv91.jpg?width=512&format=pjpg&auto=webp&s=2f93c0115d58a24e638a69f0a21fc571da99ac55", "Hello I'm Simon and I love HAVREFLARN med choklad", "Cookie lover XD", "YeBoi" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarURL", "Bio", "FunFact", "WorkStatus" },
                values: new object[] { "https://pbs.twimg.com/profile_images/1342617687663521793/4lVjmcIk_400x400.jpg", "Erik aka MuminLover1337", "I LOVE MUUUUMIN!", "Lobster" });
        }
    }
}
