using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Data;
using LeisureTimeSystem.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Services
{
    public class Service
    {
        private LeisureSystemContext context;

        private UserManager<ApplicationUser> userManager;

        protected Service()
        {
            this.context = new LeisureSystemContext();
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));

        }

        protected LeisureSystemContext Context => this.context;

        protected UserManager<ApplicationUser> UserManager => this.userManager;
    }
}
