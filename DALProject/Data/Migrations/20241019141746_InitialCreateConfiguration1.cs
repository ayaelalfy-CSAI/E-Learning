using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALProject.Data.Migrations
{
    public partial class InitialCreateConfiguration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseExams_CourseId",
                table: "StudentCourseExams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseExams_ExamId",
                table: "StudentCourseExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseExams_StudentId",
                table: "StudentCourseExams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseAssignments_AssignmentId",
                table: "StudentCourseAssignments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseAssignments_CourseId",
                table: "StudentCourseAssignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseAssignments_StudentId",
                table: "StudentCourseAssignments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseAssignments_Assignments_AssignmentId",
                table: "StudentCourseAssignments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseAssignments_Courses_CourseId",
                table: "StudentCourseAssignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseAssignments_Students_StudentId",
                table: "StudentCourseAssignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseExams_Courses_CourseId",
                table: "StudentCourseExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseExams_Exams_ExamId",
                table: "StudentCourseExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourseExams_Students_StudentId",
                table: "StudentCourseExams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseAssignments_Assignments_AssignmentId",
                table: "StudentCourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseAssignments_Courses_CourseId",
                table: "StudentCourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseAssignments_Students_StudentId",
                table: "StudentCourseAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseExams_Courses_CourseId",
                table: "StudentCourseExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseExams_Exams_ExamId",
                table: "StudentCourseExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourseExams_Students_StudentId",
                table: "StudentCourseExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseExams_CourseId",
                table: "StudentCourseExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseExams_ExamId",
                table: "StudentCourseExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseExams_StudentId",
                table: "StudentCourseExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseAssignments_AssignmentId",
                table: "StudentCourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseAssignments_CourseId",
                table: "StudentCourseAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourseAssignments_StudentId",
                table: "StudentCourseAssignments");
        }
    }
}
