using Microsoft.EntityFrameworkCore.Migrations;

namespace UNAProject.Infrastructure.Data.Migrations
{
    public partial class AddLeadImageNameToPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeadImageName",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeadImageName",
                table: "Publications");
        }
    }
}
