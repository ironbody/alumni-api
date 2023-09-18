using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniAPI.Migrations
{
    /// <inheritdoc />
    public partial class GroupCreatorRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatorId",
                table: "Group",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_CreatorId",
                table: "Group",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_CreatorId",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_CreatorId",
                table: "Group");
        }
    }
}
