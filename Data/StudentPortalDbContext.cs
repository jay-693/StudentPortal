using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Data
{
        public class StudentPortalDbContext : DbContext
        {
            public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
                : base(options)
            {
            }

            // Add DbSet properties for each table in your database
            public DbSet<SignUp> SignUps { get; set; } // Example table for the SignUp model
            public DbSet<Holiday> Holidays { get; set; }
            public DbSet<ExamTimeTable> ExamTimeTables { get; set; }

    }
}
