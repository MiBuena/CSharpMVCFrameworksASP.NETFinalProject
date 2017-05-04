using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using LeisureTimeSystem.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data.Interfaces
{
    public interface ILeisureTimeSystemDbContext
    {

        void SetModified(object entity, object newValues);

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<IdentityRole> Roles { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Course> Courses { get; set; }

        DbSet<Discipline> Disciplines { get; set; }

        DbSet<Organization> Organizations { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<CourseApplicationData> CoursesApplications { get; set; }

        DbSet<Address> Addresses { get; set; }

        DbSet<Picture> Pictures { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<Article> Articles { get; set; }

        int SaveChanges();
    }
}
