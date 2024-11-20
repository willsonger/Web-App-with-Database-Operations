using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FancySignup.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserLogins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                column: "Id");
        }
    }
}
