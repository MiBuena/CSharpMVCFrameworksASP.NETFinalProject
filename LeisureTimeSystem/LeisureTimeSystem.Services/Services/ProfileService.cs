using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class ProfileService : Service
    {
        public DetailsProfileViewModel GetProfileDetailsProfileViewModel(string currentUserId)
        {
            var student = this.Context.Students.FirstOrDefault(x => x.UserId == currentUserId);

            var detailsProfileViewModel = Mapper.Map<Student, DetailsProfileViewModel>(student);

            return detailsProfileViewModel;
        }
    }
}
