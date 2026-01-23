using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TellADoc.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Document",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Document",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Document",
                newName: "UploadedAt");
        }
    }
}
