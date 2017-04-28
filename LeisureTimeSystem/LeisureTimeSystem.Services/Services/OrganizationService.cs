using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Models.ViewModels.Profile;

namespace LeisureTimeSystem.Services.Services
{
    public class OrganizationService : Service
    {
        public IEnumerable<CourseViewModel> GetAllOrganizationCourses(int organizationId)
        {
            var courses = this.Context.Courses.Where(x => x.Organization.Id == organizationId);

            var coursesVms = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return coursesVms;
        }
        public void UploadPicture(UploadOrganizationPictureBindingModel model, HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            var fileName = GetFileName(file, server);

            string fullFilePath = "../UploadedFiles/" + fileName;

            Picture newPicture = new Picture()
            {
                Path = fullFilePath
            };

            var organization = this.Context.Organizations.Find(model.Id);

            organization.Pictures.Add(newPicture);

            this.Context.SaveChanges();
        }

        private string GetFileName(HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            string fileName = Path.GetFileName(file.FileName);

            string path = Path.Combine(server.MapPath("~/UploadedFiles"), fileName);

            file.SaveAs(path);

            return fileName;
        }

        public UploadOrganizationPictureViewModel GetUploadOrganizationPictureViewModel(int organizationId)
        {
            UploadOrganizationPictureViewModel model = new UploadOrganizationPictureViewModel()
            {
                Id = organizationId
            };

            return model;
        }


        public DeletePictureViewModel GetDeletePictureViewModel(int pictureId, int organizationId)
        {
            var picture = this.Context.Pictures.Find(pictureId);

            var pictureVm = Mapper.Map<Picture, DeletePictureViewModel>(picture);
            pictureVm.OrganizationId = organizationId;

            return pictureVm;
        }

        public void DeletePicture(DeletePictureBindingModel model)
        {
            var pictureToDelete = this.Context.Pictures.FirstOrDefault(x => x.Id == model.PictureId);

            this.Context.Pictures.Remove(pictureToDelete);

            this.Context.SaveChanges();
        }

        public EditOrganizationDataViewModel GetEditOrganizationDataViewModel(int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            var editOrganizationDataViewModel = Mapper.Map<Organization, EditOrganizationDataViewModel>(organization);

            return editOrganizationDataViewModel;
        }

        public EditOrganizationDescriptionViewModel GetEditOrganizationDescriptionViewModel(int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            var editOrganizationDataViewModel = Mapper.Map<Organization, EditOrganizationDescriptionViewModel>(organization);

            return editOrganizationDataViewModel;
        }

        public EditOrganizationPicturesViewModel GetEditOrganizationPicturesViewModel(int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            EditOrganizationPicturesViewModel model = Mapper.Map<Organization, EditOrganizationPicturesViewModel>(organization);

            return model;
        }



        public void EditOrganizationData(EditOrganizationDataBindingModel model)
        {
            var organization = this.Context.Organizations.Find(model.Id);

            this.Context.Entry(organization).CurrentValues.SetValues(model);

            var address = this.Context.Addresses.Find(organization.Address.Id);

            this.Context.Entry(address).CurrentValues.SetValues(model.Address);

            this.Context.SaveChanges();
        }


        public void EditOrganizationDescription(EditOrganizationDescriptionBindingModel model)
        {
            var organization = this.Context.Organizations.Find(model.Id);

            organization.Description = model.Description;

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

