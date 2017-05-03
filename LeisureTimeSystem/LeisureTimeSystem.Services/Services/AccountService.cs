using System;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Services.Interfaces;

namespace LeisureTimeSystem.Services.Services
{
    public class AccountService : Service, IAccountService
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
