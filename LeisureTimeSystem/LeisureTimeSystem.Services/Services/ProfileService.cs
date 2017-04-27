﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Profile;

namespace LeisureTimeSystem.Services.Services
{
    public class ProfileService : Service
    {
        public DetailsProfileViewModel GetProfileDetailsProfileViewModel(string currentUserId)
        {
            var currentUser = this.Context.Users.Find(currentUserId);

           var student = this.Context.Students.Include(x=>x.Address).FirstOrDefault(x => x.UserId == currentUserId);

            var detailsProfileViewModel = Mapper.Map<Student, DetailsProfileViewModel>(student);

            detailsProfileViewModel.Username = currentUser.UserName;

            detailsProfileViewModel.Email = currentUser.Email;

            return detailsProfileViewModel;
        }

        public EditProfileViewModel GetEditProfileViewModel(int studentId)
        {
            var student = this.Context.Students.Include(x=>x.User).FirstOrDefault(y=>y.Id == studentId);

            var editProfileViewModel = Mapper.Map<Student, EditProfileViewModel>(student);

            editProfileViewModel.Username = student.User.UserName;

            editProfileViewModel.Email = student.User.Email;

            return editProfileViewModel;
        }

        public void EditProfile(EditProfileBindingModel model)
        {
            var student = this.Context.Students.Include(x=>x.Address).Include(x => x.User).FirstOrDefault(y => y.Id == model.Id);

            this.Context.Entry(student).CurrentValues.SetValues(model);

            student.User.UserName = model.Username;
            student.User.Email = model.Email;

            UpdateAddress(model, student);

            this.Context.SaveChanges();
        }

        private void UpdateAddress(EditProfileBindingModel model, Student student)
        {
            Address address = Mapper.Map<AddressBindingModel, Address>(model.Address);

            if (student.Address == null)
            {
                this.Context.Addresses.Add(address);
                student.Address = address;
            }
            else
            {
                var studentAddress = student.Address;

                this.Context.Entry(studentAddress).CurrentValues.SetValues(model.Address);
            }
        }


    }
}
