﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models
{
    public class ExamTimeTable
    {
            public int Id { get; set; }
            public int Sno { get; set; }
            public string SubjectCode { get; set; }
            public string Subject { get; set; }
            public DateTime ExamDate { get; set; }
            public string Timing { get; set; }
            public int Semester { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        [ForeignKey("StudentId")]
        public SignUp SignUp { get; set; }
    }
}
