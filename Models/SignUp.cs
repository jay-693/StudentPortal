using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class SignUp
    {
        // Primary key for StudentId
        [Key] // Data annotation to mark this as the primary key
        public int StudentId { get; set; }

        // Username field with required validation
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        public string Username { get; set; }

        // Password field with required validation
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        // Confirm password field with comparison to the Password field
        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

