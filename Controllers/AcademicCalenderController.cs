using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace YourNamespace.Controllers
{
    public class AcademicCalendarController : Controller
    {
        [HttpGet]
        public IActionResult DownloadPdf(int sem)
        {
            // Define the path where your PDFs are stored
            string pdfDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs");
            string pdfFile = string.Empty;

            // Select the PDF based on the semester
            switch (sem)
            {
                case 1:
                    pdfFile = Path.Combine(pdfDirectory, "Semester1.pdf");
                    break;
                case 2:
                    pdfFile = Path.Combine(pdfDirectory, "Semester2.pdf");
                    break;
                case 3:
                    pdfFile = Path.Combine(pdfDirectory, "Semester3.pdf");
                    break;
                case 4:
                    pdfFile = Path.Combine(pdfDirectory, "Semester4.pdf");
                    break;
                case 5:
                    pdfFile = Path.Combine(pdfDirectory, "Semester5.pdf");
                    break;
                case 6:
                    pdfFile = Path.Combine(pdfDirectory, "Semester6.pdf");
                    break;
                case 7:
                    pdfFile = Path.Combine(pdfDirectory, "Semester7.pdf");
                    break;
                case 8:
                    pdfFile = Path.Combine(pdfDirectory, "Semester8.pdf");
                    break;
                default:
                    return NotFound();
            }

            if (System.IO.File.Exists(pdfFile))
            {
                // Send the PDF file as a response to be downloaded
                byte[] fileBytes = System.IO.File.ReadAllBytes(pdfFile);
                return File(fileBytes, "application/pdf", Path.GetFileName(pdfFile));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult DownloadHolyPdf(int sem)
        {
            // Define the path where your PDFs are stored
            string pdfDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs");
            string pdfFile = string.Empty;

            // Select the PDF based on the semester
            switch (sem)
            {
                case 1:
                    pdfFile = Path.Combine(pdfDirectory, "Sem1.pdf");
                    break;
                case 2:
                    pdfFile = Path.Combine(pdfDirectory, "Semester2.pdf");
                    break;
                case 3:
                    pdfFile = Path.Combine(pdfDirectory, "Semester3.pdf");
                    break;
                case 4:
                    pdfFile = Path.Combine(pdfDirectory, "Semester4.pdf");
                    break;
                case 5:
                    pdfFile = Path.Combine(pdfDirectory, "Semester5.pdf");
                    break;
                case 6:
                    pdfFile = Path.Combine(pdfDirectory, "Semester6.pdf");
                    break;
                case 7:
                    pdfFile = Path.Combine(pdfDirectory, "Semester7.pdf");
                    break;
                case 8:
                    pdfFile = Path.Combine(pdfDirectory, "Semester8.pdf");
                    break;
                default:
                    return NotFound();
            }

            if (System.IO.File.Exists(pdfFile))
            {
                // Send the PDF file as a response to be downloaded
                byte[] fileBytes = System.IO.File.ReadAllBytes(pdfFile);
                return File(fileBytes, "application/pdf", Path.GetFileName(pdfFile));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
