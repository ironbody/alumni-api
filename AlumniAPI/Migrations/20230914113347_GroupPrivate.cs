using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class GroupPrivate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Group",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "Private",
                value: false);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2,
                column: "Private",
                value: false);

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "Private",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Private",
                table: "Group");
        }
    }
}
