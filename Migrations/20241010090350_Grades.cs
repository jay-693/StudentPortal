using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Migrations
{
    /// <inheritdoc />
    public partial class Grades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemwiseGradesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sno = table.Column<int>(type: "int", nullable: false),
                    SubjectcodeLabCode = table.Column<string>(name: "Subject code/Lab Code", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectNameLabName = table.Column<string>(name: "Subject Name/Lab Name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Monthyear = table.Column<string>(name: "Month&year", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemwiseGradesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemwiseGradesDetails_SignUps_StudentId",
                        column: x => x.StudentId,
                        principalTable: "SignUps",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemwiseGradesDetails_StudentId",
                table: "SemwiseGradesDetails",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemwiseGradesDetails");
        }
    }
}
