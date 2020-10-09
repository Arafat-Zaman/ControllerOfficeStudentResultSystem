using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerOfficeStudentResultSystem.Migrations
{
    public partial class SeedStudentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Program", "SubjectName", "Year" },
                values: new object[] { 1, "BSc", "Botany", "_2020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
