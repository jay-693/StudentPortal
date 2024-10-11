using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Migrations
{
    /// <inheritdoc />
    public partial class @internal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabInternalMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sno = table.Column<int>(type: "int", nullable: false),
                    SubjectCodeLabCode = table.Column<string>(name: "Subject Code/Lab Code", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectNameLabName = table.Column<string>(name: "Subject Name/Lab Name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MidMarks30LabInternalMarks40 = table.Column<decimal>(name: "Mid Marks(30)/Lab InternalMarks(40)", type: "decimal(18,2)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabInternalMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabInternalMarks_SignUps_StudentId",
                        column: x => x.StudentId,
                        principalTable: "SignUps",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabInternalMarks_StudentId",
                table: "LabInternalMarks",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabInternalMarks");
        }
    }
}
