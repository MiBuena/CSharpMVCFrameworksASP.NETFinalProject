using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Data.Mocks.DBSets;
using LeisureTimeSystem.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data.Mocks
{
    public class FakeLeisureTimeDbContext : ILeisureTimeSystemDbContext
    {
        public FakeLeisureTimeDbContext()
        {
            this.Students = new FakeStudentsDbSet();
            this.Courses = new FakeCoursesDbSet();
            this.Disciplines = new FakeDisciplinesDbSet();
            this.Organizations = new FakeOrganizationsDbSet();
            this.Comments = new FakeCommentsDbSet();
            this.Addresses = new FakeAddressesDbSet();
            this.Articles = new FakeArticlesDbSet();
            this.Categories = new FakeCategoriesDbSet();
            this.CoursesApplications = new FakeCourseApplicationDataDbSet();
            this.Pictures = new PicturesDbSet();
            this.Tags = new FakeTagsDbSet();
            this.Roles = new FakeRolesDbSet();
            this.Users = new FakeUsersDbSet();
        }


        public void SetModified(object entityToModify, object newValues)
        {
            var firstProperties = entityToModify.GetType().GetProperties();
            var secondProperties = newValues.GetType().GetProperties();

            foreach (var oldProperty in firstProperties)
            {
                var newProperty = secondProperties.FirstOrDefault(x => x.Name == oldProperty.Name);

                var type = newProperty.GetValue(newValues).GetType();

                if (typeof(IConvertible).IsAssignableFrom(type))
                {
                    var a = Convert.ChangeType(newProperty.GetValue(newValues), oldProperty.PropertyType);
                    oldProperty.SetValue(entityToModify, a, null);

                }

            }

            this.SaveChanges();
        }

        public virtual IDbSet<ApplicationUser> Users { get; set; }

        public virtual IDbSet<IdentityRole> Roles { get; set; }

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

        public int SaveChanges()
        {
            return 0;
        }
    }
}
