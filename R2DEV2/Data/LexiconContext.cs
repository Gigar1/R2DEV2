using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using R2DEV2.Models;
using Microsoft.EntityFrameworkCore;

namespace R2DEV2.Data
{
    public class LexiconContext : DbContext
    {
        public LexiconContext(DbContextOptions<LexiconContext> options) : base(options)
        {

        }
        public DbSet<CourseClass> Courses { get; set; }
        public DbSet<ModuleClass> Modules { get; set; }
        public DbSet<ActivityClass> Activities { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseClass>().ToTable("Course");
            modelBuilder.Entity<ModuleClass>().ToTable("Module");
            modelBuilder.Entity<ActivityClass>().ToTable("Activity");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}