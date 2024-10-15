/*using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using StudentPortal.Data;
using System.Text;

namespace StudentPortal.Controllers
{
    public class HolidaysController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public HolidaysController(StudentPortalDbContext context)
        {
            _context = context;
        }

        public IActionResult Holidaylist()
        {
            // Fetch only the required columns from the Holidays table
            var holidays = _context.Holidays
                .Select(h => new { h.Month, h.Date, h.Day, h.Occasion })
                .ToList();

            return View(holidays);
        }

        public IActionResult Holidaypdf()
        {
            var holidays = _context.Holidays
                .Select(h => new { h.Month, h.Date, h.Day, h.Occasion })
                .ToList();

            return View(holidays);
        }
        [HttpGet]
        public IActionResult DownloadHolidaysPdf()
        {
            // Fetch the holiday data from the database
            var holidays = _context.Holidays.ToList();

            // Return the view as a PDF using Rotativa
            return new ViewAsPdf("Holidaypdf", holidays)
            {
                FileName = "Holidays.pdf", // Name of the file to download
                PageSize = Rotativa.AspNetCore.Options.Size.A4, // Set the PDF size
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait, // Set page orientation
                PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10) // Set page margins
            };
        }
        
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using StudentPortal.Data;
using System.Linq;

namespace StudentPortal.Controllers
{
    public class HolidaysController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public HolidaysController(StudentPortalDbContext context)
        {
            _context = context;
        }

        // Action to show paginated list of holidays
        public IActionResult Holidaylist(int pageNumber = 1, int pageSize = 10)
        {
            // Fetch holidays with pagination
            var holidays = _context.Holidays
                .Select(h => new { h.Month, h.Date, h.Day, h.Occasion })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Pass the current page number and total count to the view
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(_context.Holidays.Count() / (double)pageSize);

            return View(holidays);
        }

        // Action to show all holidays in PDF (without pagination)
        public IActionResult Holidaypdf()
        {
            var holidays = _context.Holidays
                .Select(h => new { h.Month, h.Date, h.Day, h.Occasion })
                .ToList();

            return View(holidays);
        }

        [HttpGet]
        public IActionResult DownloadHolidaysPdf()
        {
            // Fetch the holiday data from the database
            var holidays = _context.Holidays.ToList();

            // Return the view as a PDF using Rotativa
            return new ViewAsPdf("Holidaypdf", holidays)
            {
                FileName = "Holidays.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10)
            };
        }
    }
}
