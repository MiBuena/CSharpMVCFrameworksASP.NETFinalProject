using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Data;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Services
{
    public class Service
    {
        private ILeisureTimeSystemDbContext context;

        private UserManager<ApplicationUser> userManager;

        protected Service(ILeisureTimeSystemDbContext context)
        {
            this.context = context;
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new LeisureSystemContext()));

        }

        protected ILeisureTimeSystemDbContext Context => this.context;

        protected UserManager<ApplicationUser> UserManager => this.userManager;
    }
}
