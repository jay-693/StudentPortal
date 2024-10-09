using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;

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
            Console.WriteLine($"Requested semester: {semester}");

            // Fetch the exam timetable from the database based on the semester.
            var examTimeTable = _context.ExamTimeTables
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)  // Order by SNO
                                        .ToList();
            Console.WriteLine($"Retrieved {examTimeTable.Count} records for semester {semester}");

            return PartialView("_ExamTimeTable", examTimeTable);
        }
        public IActionResult ExamTimeTable()
        {
            return View();
        }
    }
}
