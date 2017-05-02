using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Exceptions;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;
using Constants = LeisureTimeSystem.Models.Utils.Constants;

namespace LeisureTimeSystem.Controllers
{
    [HandleError(ExceptionType = typeof(NotAuthorizedException), View = "Error")]
    public class OrganizationController : Controller
    {
        private OrganizationService service;

        public OrganizationController()
        {
            this.service = new OrganizationService();
        }

        [LeisureTimeAuthorize]
        public ActionResult AddRepresentative(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationMembersExceptionMessage);

            var addRepresentativeViewModel = this.service.GetAddRepresentativeViewModel(organizationId);

            return this.PartialView(addRepresentativeViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult AddRepresentative(AddRepresentativeBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.OrganizationId, Constants.ManageOrganizationMembersExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.AddRepresentative(model);

                return this.RedirectToAction("ManageRepresentatives", new {organizationId = model.OrganizationId});
            }

            var addRepresentativeViewModel = this.service.GetAddRepresentativeViewModel(model.OrganizationId);

            return this.PartialView(addRepresentativeViewModel);
        }


        [LeisureTimeAuthorize]
        public ActionResult RemoveRepresentative(int organizationId, int studentId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationMembersExceptionMessage);

            var removeRepresentativeViewModel = this.service.GetRemoveRepresentativeViewModel(studentId, organizationId);

            return this.PartialView(removeRepresentativeViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult RemoveRepresentative(RemoveRepresentativeBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.OrganizationId, Constants.ManageOrganizationMembersExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.RemoveRepresentative(model);

                return this.RedirectToAction("ManageRepresentatives", new {organizationId = model.OrganizationId});
            }

            var removeRepresentativeViewModel = this.service.GetRemoveRepresentativeViewModel(model.RepresentativeId, model.OrganizationId);

            return this.PartialView(removeRepresentativeViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult ManageRepresentatives(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationMembersExceptionMessage);

            var addRepresentativesViewModel = this.service.GetManageRepresentativesViewModel(organizationId);

            return this.View(addRepresentativesViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Delete(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationMembersExceptionMessage);

            var deleteorganizationViewModel = this.service.GetDeleteOrganizationViewModel(organizationId);

            return View(deleteorganizationViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Delete(DeleteOrganizationBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.Id, Constants.ManageOrganizationMembersExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.DeleteOrganization(model.Id);

                return this.RedirectToAction("Index", "Home");
            }

            var deleteViewModel = this.service.GetDeleteOrganizationViewModel(model.Id);

            return this.View(deleteViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult ControlPanel(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationMembersExceptionMessage);

            var organizationViewModel = this.service.GetDetailsOrganizationViewModel(organizationId);

            return View(organizationViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult ManageOrganizationCourses(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.ManageOrganizationCoursesExceptionMessage);

            var courseViewModels = this.service.GetAllOrganizationCourses(organizationId);

            return this.View(courseViewModels);
        }



        public ActionResult AllOrganizationCourses(int organizationId)
        {
            var courseViewModels = this.service.GetAllOrganizationCourses(organizationId);

            return this.PartialView(courseViewModels);
        }

        public ActionResult Details(int organizationId)
        {
            var organizationViewModel = this.service.GetDetailsOrganizationViewModel(organizationId);

            return View(organizationViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Create()
        {
            var addOrganizationViewModel = this.service.GetViewModel();

            return View(addOrganizationViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
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

            organizationViewModel.Disciplines = this.service.GetDisciplinesViewModels();

            return View(organizationViewModel);

        }

        [LeisureTimeAuthorize]
        public ActionResult EditOrganizationData(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.EditOrganizationProfileExceptionMessage);


            var organizationViewModel = this.service.GetEditOrganizationDataViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult EditOrganizationData(EditOrganizationDataBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.Id, Constants.ManageOrganizationCoursesExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.EditOrganizationData(model);
                return this.RedirectToAction("Details", new {organizationId = model.Id});
            }

            return this.View(this.service.GetEditOrganizationDataViewModel(model.Id));
        }

        [LeisureTimeAuthorize]
        public ActionResult EditOrganizationDescription(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.EditOrganizationProfileExceptionMessage);

            var organizationViewModel = this.service.GetEditOrganizationDescriptionViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }


        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult EditOrganizationDescription(EditOrganizationDescriptionBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.Id, Constants.EditOrganizationProfileExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.EditOrganizationDescription(model);
                return this.RedirectToAction("Details", new {organizationId = model.Id});
            }

            return this.View(this.service.GetEditOrganizationDescriptionViewModel(model.Id));
        }


        [LeisureTimeAuthorize]
        public ActionResult EditOrganizationPictures(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.EditOrganizationProfileExceptionMessage);

            var organizationViewModel = this.service.GetEditOrganizationPicturesViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult DeletePicture(int pictureId, int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.EditOrganizationProfileExceptionMessage);

            var pictureVm = this.service.GetDeletePictureViewModel(pictureId, organizationId);

            return View(pictureVm);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult DeletePicture(DeletePictureBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.OrganizationId, Constants.EditOrganizationProfileExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.DeletePicture(model);
                return this.RedirectToAction("Details", new {organizationId = model.OrganizationId});
            }

            return this.View(this.service.GetDeletePictureViewModel(model.PictureId, model.OrganizationId));
        }

        [LeisureTimeAuthorize]
        public ActionResult UploadFile(int organizationId)
        {
            CheckIfUserIsAllowedToPerformThisAction(organizationId, Constants.EditOrganizationProfileExceptionMessage);

            var organizationViewModel = this.service.GetUploadOrganizationPictureViewModel(organizationId);

            return this.PartialView(organizationViewModel);
        }


        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Upload(UploadOrganizationPictureBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.Id, Constants.EditOrganizationProfileExceptionMessage);

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

        private void CheckIfUserIsAllowedToPerformThisAction(int organizationId, string message)
        {
            string currentUserId = User.Identity.GetUserId();

            var isOrganizationRepresentative = this.service.IsOrganizationRepresentative(currentUserId, organizationId);

            if (!isOrganizationRepresentative)
            {
                throw new NotAuthorizedException(message);
            }
        }
    }
}