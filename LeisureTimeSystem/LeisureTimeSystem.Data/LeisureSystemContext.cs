using System.Globalization;
using System.Runtime.Remoting.Contexts;
using LeisureTimeSystem.Data.Migrations;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LeisureSystemContext : IdentityDbContext<ApplicationUser>
    {
        public LeisureSystemContext()
            : base("name=LeisureTimeSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LeisureSystemContext, Configuration>());
        }

        public static LeisureSystemContext Create()
        {
            return new LeisureSystemContext();
        }


        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Discipline> Disciplines { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CourseApplicationData> CoursesApplications { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Subcategories).WithOptional(x => x.ParentCategory);

            modelBuilder.Entity<Student>()
.HasMany(st => st.AllCourseApplicationsAsAStudent)
.WithRequired(x => x.Student)
.WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}