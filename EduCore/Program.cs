using EduCore.Models;
using EduCore.Models.Data;
using EduCore.Repository;
using EduCore.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<AppDbContext>(
                option=>option.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();



            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ICrsResultRepository, CrsResultRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();

      
        }
    }
}
