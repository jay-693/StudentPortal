using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class LabInternalMarksController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public LabInternalMarksController(StudentPortalDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetLabInternalMarks(int semester)
        {
            // Check if the semester value is valid
            if (semester <= 0)
            {
                return BadRequest("Invalid semester value.");
            }
            TempData["Semester"] = semester;
            // Fetch the exam timetable from the database based on the semester
            var labInternalMarks = _context.LabInternalMarks
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)  // Order by SNO
                                        .ToList();

            if (labInternalMarks == null || !labInternalMarks.Any())
            {
                // Return partial view with a message if no data found
                return PartialView("_LabInternalMarks", new List<LabInternalMarks>());
            }

            return PartialView("_LabInternalMarks", labInternalMarks);
        }
        public IActionResult DownloadLabInternalMarks(int semester)
        {
            var labInternalMarks = _context.LabInternalMarks
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)
                                        .ToList();
            TempData["Semester"] = semester;
            /*if (examTimeTable == null || !examTimeTable.Any())
            {
                return NotFound("No exam timetable found for the selected semester.");
            }*/

            // Return the view as a PDF using Rotativa
            return new ViewAsPdf("LabInternalMarksPdf", labInternalMarks)
            {
                FileName = $"InternalMarks_Semester_{semester}.pdf"
            };
        }
        public IActionResult LabInternalMarks()
        {
            return View();
        }
    }
}

