using Microsoft.EntityFrameworkCore.Migrations;

namespace UNAProject.Infrastructure.Data.Migrations
{
    public partial class RefactorAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoragePath",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Attachments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Attachments",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Attachments",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attachments",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "StoragePath",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
