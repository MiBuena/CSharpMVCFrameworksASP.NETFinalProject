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

        protected Service(ILeisureTimeSystemDbContext context)
        {
            this.context = context;
        }

        protected ILeisureTimeSystemDbContext Context => this.context;
    }
}
