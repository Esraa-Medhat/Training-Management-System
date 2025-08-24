using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Presistance.Data;
using Training_Management_System.DAL.Presistance.Repositories.Courses;
using Training_Management_System.DAL.Presistance.Repositories.Grades;
using Training_Management_System.DAL.Presistance.Repositories.Sessions;
using Training_Management_System.DAL.Presistance.Repositories.Users;
using Training_Management_System.PLL.Services.Course;
using Training_Management_System.PLL.Services.GradeService;
using Training_Management_System.PLL.Services.SessionService;
using Training_Management_System.PLL.Services.UserService;

namespace Training_Management_Sysytem.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Cofigure Services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>((optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }));
            #endregion

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IGradeRepository, GradeRepository>();
            builder.Services.AddScoped<IGradeService, GradeService>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
