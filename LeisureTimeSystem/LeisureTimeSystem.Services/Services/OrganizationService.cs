using System;
using System.Collections;
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
        public AddOrganizationViewModel GetViewModel()
        {
            AddOrganizationViewModel model = new AddOrganizationViewModel();

            var disciplineViewModels = this.GetDisciplinesViewModels();

            model.Disciplines = disciplineViewModels;

            return model;
        }

        public void CreateOrganization(AddOrganizationBindingModel model)
        {
            var organization = Mapper.Map<AddOrganizationBindingModel, Organization>(model);

            var representative = this.Context.Students.FirstOrDefault(x => x.UserId == model.RepresentativeId);

            organization.Representatives.Add(representative);

            AddDiscipline(model, organization);

            AddAddress(model, organization);

            this.Context.Organizations.Add(organization);

            this.Context.SaveChanges();
        }

        private void AddDiscipline(AddOrganizationBindingModel model, Organization organization)
        {
            var discipline = this.Context.Disciplines.Find(model.DisciplineId);

            organization.Disciplines.Add(discipline);
        }

        private void AddAddress(AddOrganizationBindingModel model, Organization organization)
        {
            var address = Mapper.Map<AddressBindingModel, Address>(model.Address);

            this.Context.Addresses.Add(address);

            organization.Address = address;
        }

        public ICollection<AddOrganizationDisciplineViewModel> GetDisciplinesViewModels()
        {
            var disciplines = this.Context.Disciplines.ToList();

            var vms = Mapper.Map<ICollection<Discipline>, ICollection<AddOrganizationDisciplineViewModel>>(disciplines);

            return vms;
        }
    }
}
