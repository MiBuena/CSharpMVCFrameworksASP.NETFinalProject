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