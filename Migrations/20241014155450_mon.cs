using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Migrations
{
    /// <inheritdoc />
    public partial class mon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamTimeTables_SignUps_StudentId",
                table: "ExamTimeTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_SignUps_StudentId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LabInternalMarks_SignUps_StudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_SemwiseGradesDetails_SignUps_StudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SemwiseGradesDetails_StudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropIndex(
                name: "IX_LabInternalMarks_StudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_StudentId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_ExamTimeTables_StudentId",
                table: "ExamTimeTables");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ExamTimeTables");

            migrationBuilder.AddColumn<int>(
                name: "SignUpStudentId",
                table: "SemwiseGradesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignUpStudentId",
                table: "LabInternalMarks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignUpStudentId",
                table: "Holidays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignUpStudentId",
                table: "ExamTimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemwiseGradesDetails_SignUpStudentId",
                table: "SemwiseGradesDetails",
                column: "SignUpStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabInternalMarks_SignUpStudentId",
                table: "LabInternalMarks",
                column: "SignUpStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_SignUpStudentId",
                table: "Holidays",
                column: "SignUpStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTimeTables_SignUpStudentId",
                table: "ExamTimeTables",
                column: "SignUpStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamTimeTables_SignUps_SignUpStudentId",
                table: "ExamTimeTables",
                column: "SignUpStudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_SignUps_SignUpStudentId",
                table: "Holidays",
                column: "SignUpStudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabInternalMarks_SignUps_SignUpStudentId",
                table: "LabInternalMarks",
                column: "SignUpStudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SemwiseGradesDetails_SignUps_SignUpStudentId",
                table: "SemwiseGradesDetails",
                column: "SignUpStudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamTimeTables_SignUps_SignUpStudentId",
                table: "ExamTimeTables");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_SignUps_SignUpStudentId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_LabInternalMarks_SignUps_SignUpStudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_SemwiseGradesDetails_SignUps_SignUpStudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropIndex(
                name: "IX_SemwiseGradesDetails_SignUpStudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropIndex(
                name: "IX_LabInternalMarks_SignUpStudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_SignUpStudentId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_ExamTimeTables_SignUpStudentId",
                table: "ExamTimeTables");

            migrationBuilder.DropColumn(
                name: "SignUpStudentId",
                table: "SemwiseGradesDetails");

            migrationBuilder.DropColumn(
                name: "SignUpStudentId",
                table: "LabInternalMarks");

            migrationBuilder.DropColumn(
                name: "SignUpStudentId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "SignUpStudentId",
                table: "ExamTimeTables");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "SemwiseGradesDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "LabInternalMarks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ExamTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SemwiseGradesDetails_StudentId",
                table: "SemwiseGradesDetails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LabInternalMarks_StudentId",
                table: "LabInternalMarks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_StudentId",
                table: "Holidays",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTimeTables_StudentId",
                table: "ExamTimeTables",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamTimeTables_SignUps_StudentId",
                table: "ExamTimeTables",
                column: "StudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_SignUps_StudentId",
                table: "Holidays",
                column: "StudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabInternalMarks_SignUps_StudentId",
                table: "LabInternalMarks",
                column: "StudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemwiseGradesDetails_SignUps_StudentId",
                table: "SemwiseGradesDetails",
                column: "StudentId",
                principalTable: "SignUps",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
