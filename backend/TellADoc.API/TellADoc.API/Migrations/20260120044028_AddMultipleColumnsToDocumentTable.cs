using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TellADoc.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleColumnsToDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Document",
                newName: "Summary_Text");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Document",
                newName: "Storage_Path");

            migrationBuilder.AddColumn<string>(
                name: "Ai_Status",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "File_Name",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "File_Size",
                table: "Document",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "File_Type",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Original_Text",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Page_Count",
                table: "Document",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Processing_Time_Seconds",
                table: "Document",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Uploaded_At",
                table: "Document",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Document",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ai_Status",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "File_Name",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "File_Size",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "File_Type",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Original_Text",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Page_Count",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Processing_Time_Seconds",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Uploaded_At",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "Summary_Text",
                table: "Document",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Storage_Path",
                table: "Document",
                newName: "Name");

            migrationBuilder.AddColumn<float>(
                name: "Size",
                table: "Document",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
