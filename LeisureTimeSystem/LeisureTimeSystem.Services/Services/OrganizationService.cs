using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class OrganizationService : Service
    {
        public void CreateOrganization(AddOrganizationBindingModel model)
        {
            var organization = Mapper.Map<AddOrganizationBindingModel, Organization>(model);

            var representative = this.Context.Students.FirstOrDefault(x => x.UserId == model.RepresentativeId);

            organization.Representatives.Add(representative);


            AddAddress(model, organization);

            this.Context.Organizations.Add(organization);

            this.Context.SaveChanges();
        }

        private void AddAddress(AddOrganizationBindingModel model, Organization organization)
        {
            var address = Mapper.Map<AddressBindingModel, Address>(model.Address);

            this.Context.Addresses.Add(address);

            organization.Address = address;
        }
    }
}
