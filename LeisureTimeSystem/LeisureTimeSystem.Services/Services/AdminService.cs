using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels.Admin;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Admin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Services.Services
{
    public class AdminService : Service
    {

        public void RemoveRole(string roleName, string userId)
        {
            this.UserManager.RemoveFromRole(userId, roleName);

            this.Context.SaveChanges();
        }

        public void SetRoles(SetRolesBindingModel setRolesBindingModel)
        {

            foreach (var combination in setRolesBindingModel.PersonRoles)
            {
                if (combination.NewRoleName != null)
                {
                    this.UserManager.AddToRole(combination.Id, combination.NewRoleName);
                }
            }

            this.Context.SaveChanges();
        }

        public SetRolesViewModel GetSetRolesViewModel()
        {
            SetRolesViewModel model = new SetRolesViewModel();

            var roles = this.Context.Roles.ToList();

            var rolesViewModels = Mapper.Map<List<IdentityRole>, List<RoleViewModel>>(roles);

            model.AllRoles = rolesViewModels;



            var users = this.Context.Users.ToList();

            model.PersonRoles = new List<PersonRoleViewModel>();


            foreach (var user in users)
            {
                var userViewModel = Mapper.Map<ApplicationUser, PersonRoleViewModel>(user);

                userViewModel.CurrentRoleViewModels = new List<RoleViewModel>();

                foreach (var role in user.Roles)
                {
                    var contextRole = this.Context.Roles.Find(role.RoleId);

                    var roleModel = Mapper.Map<IdentityRole, RoleViewModel>(contextRole);

                    userViewModel.CurrentRoleViewModels.Add(roleModel);
                }

                model.PersonRoles.Add(userViewModel);

            }

            return model;
        }

    }
}
