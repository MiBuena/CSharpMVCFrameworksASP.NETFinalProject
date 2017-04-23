using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Services.Services
{
    public class AccountService : Service
    {
        public void AddStudent(string name, string userId, DateTime birthDate)
        {
            Student student = new Student()
            {
                Name = name,
                UserId = userId,
                BirthDate = birthDate
            };


            this.Context.Students.Add(student);

            this.Context.SaveChanges();
        }
    }
}
