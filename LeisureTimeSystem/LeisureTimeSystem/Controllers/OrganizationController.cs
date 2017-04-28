using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Controllers
{
    public class OrganizationController : Controller
    {
        private OrganizationService service;

        public OrganizationController()
        {
            this.service = new OrganizationService();
        }


        public ActionResult AllOrganizationCourses(int organizationid)
        {
            var coursesVms = this.service.GetAllOrganizationCourses(organizationid);

            return this.PartialView(coursesVms);
        }

        public ActionResult Details(int organizationId)
        {
            var organizationVm = this.service.GetDetailsOrganizationViewModel(organizationId);

            return View(organizationVm);
        }

        public ActionResult Create()
        {
            var addOrganizationViewModel = this.service.GetViewModel();

            return View(addOrganizationViewModel);
        }

        [HttpPost]
        public ActionResult Create(AddOrganizationBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();

                bindingModel.RepresentativeId = currentUserId;

                this.service.CreateOrganization(bindingModel);

                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            var organizationViewModel = Mapper.Map<AddOrganizationBindingModel, AddOrganizationViewModel>(bindingModel);


            return View(organizationViewModel);

        }

        public ActionResult EditOrganizationData(int organizationId)
        {
            var organizationViewModel = this.service.GetEditOrganizationDataViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }

        [HttpPost]
        public ActionResult EditOrganizationData(EditOrganizationDataBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditOrganizationData(model);
                return this.RedirectToAction("Details", new {organizationId = model.Id});
            }

            return this.View(this.service.GetEditOrganizationDataViewModel(model.Id));
        }

        public ActionResult EditOrganizationDescription(int organizationId)
        {
            var organizationViewModel = this.service.GetEditOrganizationDescriptionViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }


        [HttpPost]
        public ActionResult EditOrganizationDescription(EditOrganizationDescriptionBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditOrganizationDescription(model);
                return this.RedirectToAction("Details", new {organizationId = model.Id});
            }

            return this.View(this.service.GetEditOrganizationDescriptionViewModel(model.Id));
        }

        
        public ActionResult EditOrganizationPictures(int organizationId)
        {
            var organizationViewModel = this.service.GetEditOrganizationPicturesViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }

        public ActionResult DeletePicture(int pictureId, int organizationId)
        {
            var pictureVm = this.service.GetDeletePictureViewModel(pictureId, organizationId);

            return View(pictureVm);
        }

        [HttpPost]
        public ActionResult DeletePicture(DeletePictureBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePicture(model);
                return this.RedirectToAction("Details", new {organizationId = model.OrganizationId});
            }

            return this.View(this.service.GetDeletePictureViewModel(model.PictureId, model.OrganizationId));
        }

        public ActionResult UploadFile(int organizationId)
        {
            var organizationViewModel = this.service.GetUploadOrganizationPictureViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }


        [HttpPost]
        public ActionResult Upload(UploadOrganizationPictureBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                HttpPostedFileBase file = this.Request.Files[0];

                this.service.UploadPicture(model, file, Server);

                return this.RedirectToAction("Details", new {organizationId = model.Id});
            }

            var organizationViewModel = this.service.GetUploadOrganizationPictureViewModel(model.Id);

            return this.PartialView("UploadFile", organizationViewModel);
        }



        public ActionResult All(int disciplineId)
        {
            var allViewModel = this.service.GetAllOrganizationsViewModels(disciplineId);

            return View(allViewModel);
        }

        public ActionResult RenderStudentOrganizations(int studentId)
        {
            var organizationsViewModels = this.service.GetOrganizations(studentId);

            return this.PartialView(organizationsViewModels);
        }
    }
}