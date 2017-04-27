using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Models.ViewModels.Profile;

namespace LeisureTimeSystem.Services.Services
{
    public class OrganizationService : Service
    {
        public EditOrganizationDataViewModel GetEditOrganizationDataViewModel(int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            var editOrganizationDataViewModel = Mapper.Map<Organization, EditOrganizationDataViewModel>(organization);

            return editOrganizationDataViewModel;
        }

        public void EditOrganizationData(EditOrganizationDataBindingModel model)
        {
            var organization = this.Context.Organizations.Find(model.Id);

            this.Context.Entry(organization).CurrentValues.SetValues(model);


            var address = this.Context.Addresses.Find(organization.Address.Id);


            this.Context.Entry(address).CurrentValues.SetValues(model.Address);


            this.Context.SaveChanges();


        }


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

        public AllDisciplineOrganizationsViewModel GetAllOrganizationsViewModels(int disciplineId)
        {
            var organizations = this.Context.Organizations.Where(x => x.Disciplines.Any(y => y.Id == disciplineId));

            var organizationsViewModels =
                Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationViewModel>>(organizations);

            var discipline = this.Context.Disciplines.Find(disciplineId);

            AllDisciplineOrganizationsViewModel model = new AllDisciplineOrganizationsViewModel()
            {
                OrganizationViewModels = organizationsViewModels,
                DisciplineName = discipline.Name
            };

            return model;
        }

        public IEnumerable<StudentProfileOrganizationViewModel> GetOrganizations(int studentId)
        {
            var student = this.Context.Students.Find(studentId);

            var organizations = student.OrganizationsTheyRepresent;

            var organizationsVms =
                Mapper.Map<IEnumerable<Organization>, IEnumerable<StudentProfileOrganizationViewModel>>(organizations);

            return organizationsVms;

        }

        public DetailsOrganizationViewModel GetDetailsOrganizationViewModel(int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            var organizationVm = Mapper.Map<Organization, DetailsOrganizationViewModel>(organization);

            return organizationVm;
        }
    }
}

