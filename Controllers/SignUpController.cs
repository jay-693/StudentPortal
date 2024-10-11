using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using LoginDemo.Filters;

namespace StudentPortal.Controllers
{
    public class SignUpController : Controller
    {
        private readonly StudentPortalDbContext _context;

        // Inject the DbContext through the constructor
        public SignUpController(StudentPortalDbContext context)
        {
            _context = context;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // Enable IDENTITY_INSERT for the SignUps table
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT SignUps ON");

                        // Add the entity with the explicit StudentId value
                        _context.SignUps.Add(signUp);
                        _context.SaveChanges();

                        // Disable IDENTITY_INSERT after the insert operation
                        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT SignUps OFF");

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback if there is an error
                        transaction.Rollback();
                        // Handle the error (log it, show a message, etc.)
                        throw new Exception("Error during registration.", ex);
                    }
                }
                return RedirectToAction("SignIn", "SignUp");
            }
            return View(signUp);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        public async Task<IActionResult> Login(string username, string password, string loginAs)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password must be provided.");
            }
                // Check user credentials
                var user = _context.SignUps.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Create the user's claims
                    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, loginAs) // Set roles like Admin/Student
        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,  // Session should persist across browser restarts
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) // Optional expiration for the session
                    };

                    // Sign in the user
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    // Optional: Set some session data
                    HttpContext.Session.SetString("UserName", user.Username);
                    HttpContext.Session.SetString("Role", loginAs);

                    // Redirect to the homepage after successful login
                    return RedirectToAction("Index", "Home", new { username = user.Username });
                }

                // If login fails, show an error message
                ViewBag.Error = "Invalid username or password.";
                return View();
            
        }
    }
}

/*       // POST: Handle Login Form Submission
       [HttpPost]
       public IActionResult Login(string username, string password, string loginAs)
       {
           // Validate the login credentials against the SignUp table
           var user = _context.SignUps.FirstOrDefault(u => u.Username == username && u.Password == password);

           if (user != null)
           {
               // User found, redirect to homepage with the username
               return RedirectToAction("Index", "Home", new { username = user.Username});
           }

           // If no user found, show an error message
           ViewBag.Error = "Invalid username or password.";
           return View();
       }
   }
}
*/