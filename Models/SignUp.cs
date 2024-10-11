﻿using System.Collections.Generic; // For the ICollection
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class SignUp
    {
        [Key] // Primary key for StudentId
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        // Navigation property for the relationship
        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<ExamTimeTable> ExamTimeTables { get; set; }
        public ICollection<LabInternalMarks> LabInternalMarks { get; set; }
        public ICollection<SemwiseGradesDetails> SemwiseGradesDetails { get; set; }

    }
}
