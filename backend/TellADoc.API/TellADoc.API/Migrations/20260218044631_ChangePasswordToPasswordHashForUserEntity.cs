using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TellADoc.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordToPasswordHashForUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "Password");
        }
    }
}
