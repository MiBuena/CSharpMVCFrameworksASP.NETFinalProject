using System.Globalization;
using System.Runtime.Remoting.Contexts;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Data.Migrations;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LeisureSystemContext : IdentityDbContext<ApplicationUser>, ILeisureTimeSystemDbContext
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


        public void SetModified(object entity, object newValues)
        {
            this.Entry(entity).CurrentValues.SetValues(newValues);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Discipline> Disciplines { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CourseApplicationData> CoursesApplications { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Subcategories).WithOptional(x => x.ParentCategory);

            modelBuilder.Entity<Article>()
.HasMany(art => art.Comments)
.WithRequired(x => x.Article)
.WillCascadeOnDelete(true);

            modelBuilder.Entity<Student>()
.HasMany(st => st.AllCourseApplicationsAsAStudent)
.WithRequired(x => x.Student)
.WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
.HasRequired(comment => comment.Author)
.WithMany(x => x.Comments)
.WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}