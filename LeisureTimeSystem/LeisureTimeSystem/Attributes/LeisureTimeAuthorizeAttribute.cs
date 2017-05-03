using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeisureTimeSystem.Attributes
{
    public class LeisureTimeAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');

            bool isUserAuthenticated = filterContext.HttpContext.Request.IsAuthenticated;

            bool isInTheCorrectRole = false;

            foreach (var role in roles)
            {
                bool isInRole = filterContext.HttpContext.User.IsInRole(role);

                if (isInRole)
                {
                    isInTheCorrectRole = true;
                    break;
                }

            }

            if (isUserAuthenticated && !isInTheCorrectRole)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}