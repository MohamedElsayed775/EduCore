using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Models.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {        
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
    }
}
