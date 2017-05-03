using System;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IAccountService
    {
        void AddStudent(string name, string userId, DateTime birthDate);
    }
}