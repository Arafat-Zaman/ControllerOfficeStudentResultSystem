using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerOfficeStudentResultSystem.Migrations
{
    public partial class AddExcelPathColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExcelPath",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcelPath",
                table: "Students");
        }
    }
}
