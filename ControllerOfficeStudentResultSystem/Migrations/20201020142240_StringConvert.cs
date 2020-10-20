using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerOfficeStudentResultSystem.Migrations
{
    public partial class StringConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "SubjectName", "Year" },
                values: new object[] { "Software_Engineering", "2020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "SubjectName", "Year" },
                values: new object[] { "Physics", "_2020" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "ExcelPath", "Program", "SubjectName", "Year" },
                values: new object[] { 2, null, "BSc", "Botany", "_2020" });
        }
    }
}
