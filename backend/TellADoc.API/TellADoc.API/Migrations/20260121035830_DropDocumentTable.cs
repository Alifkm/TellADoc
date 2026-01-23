using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TellADoc.API.Migrations
{
    /// <inheritdoc />
    public partial class DropDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ai_Status",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "Uploaded_At",
                table: "Document",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "Document",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Summary_Text",
                table: "Document",
                newName: "SummaryText");

            migrationBuilder.RenameColumn(
                name: "Storage_Path",
                table: "Document",
                newName: "StoragePath");

            migrationBuilder.RenameColumn(
                name: "Processing_Time_Seconds",
                table: "Document",
                newName: "ProcessingTimeSeconds");

            migrationBuilder.RenameColumn(
                name: "Page_Count",
                table: "Document",
                newName: "PageCount");

            migrationBuilder.RenameColumn(
                name: "Original_Text",
                table: "Document",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "File_Type",
                table: "Document",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "File_Size",
                table: "Document",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "File_Name",
                table: "Document",
                newName: "AiStatus");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Document",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Document",
                newName: "Uploaded_At");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Document",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "SummaryText",
                table: "Document",
                newName: "Summary_Text");

            migrationBuilder.RenameColumn(
                name: "StoragePath",
                table: "Document",
                newName: "Storage_Path");

            migrationBuilder.RenameColumn(
                name: "ProcessingTimeSeconds",
                table: "Document",
                newName: "Processing_Time_Seconds");

            migrationBuilder.RenameColumn(
                name: "PageCount",
                table: "Document",
                newName: "Page_Count");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Document",
                newName: "Original_Text");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "Document",
                newName: "File_Size");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Document",
                newName: "File_Type");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Document",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "AiStatus",
                table: "Document",
                newName: "File_Name");

            migrationBuilder.AddColumn<string>(
                name: "Ai_Status",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
