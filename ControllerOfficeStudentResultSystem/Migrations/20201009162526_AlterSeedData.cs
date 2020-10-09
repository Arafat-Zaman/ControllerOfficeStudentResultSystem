using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerOfficeStudentResultSystem.Migrations
{
    public partial class AlterSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "SubjectName",
                value: "Physics");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Program", "SubjectName", "Year" },
                values: new object[] { 2, "BSc", "Botany", "_2020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "SubjectName",
                value: "Botany");
        }
    }
}
