using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Models.Grades;
using Training_Management_System.DAL.Models.Sessions;
using Training_Management_System.DAL.Models.Users;

namespace Training_Management_System.DAL.Presistance.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(
            options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
        }



        #region DbSet
        public DbSet<Course>Courses{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        #endregion
    }
}
