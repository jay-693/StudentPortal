using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class SemwiseGradesDetailsController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public SemwiseGradesDetailsController(StudentPortalDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetSemwiseGradesDetails(int semester)
        {
            // Check if the semester value is valid
            if (semester <= 0)
            {
                return BadRequest("Invalid semester value.");
            }
            TempData["Semester"] = semester;
            // Fetch the exam timetable from the database based on the semester
            var semwiseGradesDetails = _context.SemwiseGradesDetails
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)  // Order by SNO
                                        .ToList();

            if (semwiseGradesDetails == null || !semwiseGradesDetails.Any())
            {
                // Return partial view with a message if no data found
                return PartialView("_SemwiseGradesDetails", new List<SemwiseGradesDetails>());
            }

            return PartialView("_SemwiseGradesDetails", semwiseGradesDetails);
        }
        public IActionResult DownloadSemwiseGradesDetails(int semester)
        {
            var semwiseGradesDetails = _context.SemwiseGradesDetails
                                        .Where(e => e.Semester == semester)
                                        .OrderBy(e => e.Sno)
                                        .ToList();
            TempData["Semester"] = semester;
            /*if (examTimeTable == null || !examTimeTable.Any())
            {
                return NotFound("No exam timetable found for the selected semester.");
            }*/

            // Return the view as a PDF using Rotativa
            return new ViewAsPdf("semwiseGradesDetailsPdf", semwiseGradesDetails)
            {
                FileName = $"SemwiseGradesDetails_Semester_{semester}.pdf"
            };
        }
        public IActionResult SemwiseGradesDetails()
        {
            return View();
        }
    }
}
