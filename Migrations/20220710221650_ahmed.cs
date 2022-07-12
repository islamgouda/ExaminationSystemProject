using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystemProject.Migrations
{
    public partial class ahmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionpools_Courses_CourseId",
                table: "Questionpools");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Questionpools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionpools_Courses_CourseId",
                table: "Questionpools",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionpools_Courses_CourseId",
                table: "Questionpools");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Questionpools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionpools_Courses_CourseId",
                table: "Questionpools",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
