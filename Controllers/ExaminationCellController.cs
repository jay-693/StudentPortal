using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class ExaminationCellController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public ExaminationCellController(StudentPortalDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetExamTimeTable(int semester)
        {
            // Check if the semester value is valid
            if (semester <= 0)
            {
                return BadRequest("Invalid semester value.");
            }
            TempData["Semester"] = semester;
            // Fetch the exam timetable from the database based on the semester
            var examTimeTable = _context.ExamTimeTables
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)  // Order by SNO
                                        .ToList();

            if (examTimeTable == null || !examTimeTable.Any())
            {
                // Return partial view with a message if no data found
                return PartialView("_ExamTimeTable", new List<ExamTimeTable>());
            }

            return PartialView("_ExamTimeTable", examTimeTable);
        }
        public IActionResult DownloadExamTimeTable(int semester)
        {
            var examTimeTable = _context.ExamTimeTables
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)
                                        .ToList();
            TempData["Semester"] = semester;
            /*if (examTimeTable == null || !examTimeTable.Any())
            {
                return NotFound("No exam timetable found for the selected semester.");
            }*/

            // Return the view as a PDF using Rotativa
            return new ViewAsPdf("ExamTimeTablePdf", examTimeTable)
            {
                FileName = $"ExamTimeTable_Semester_{semester}.pdf"
            };
        }
        public IActionResult ExamTimeTable()
        {
            return View();
        }
    }
}
