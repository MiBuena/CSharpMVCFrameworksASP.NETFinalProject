using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.Utils
{
    public static class Constants
    {
        public const string ModifyCommentsExceptionMessage = "You are not allowed to modify this comment.";

        public const string AddCoursesExceptionMessage = "You are not allowed to add a course to this organization.";

        public const string ModifyCourseExceptionMessage = "You are not allowed to modify this course.";

        public const string ModifyCourseApplicationsExceptionMessage =
            "You are not allowed to modify the applications for this course.";

        public const string ManageOrganizationMembersExceptionMessage =
            "Only representatives of the organization can add/remove other representatives to the organization.";

        public const string ManagementPanelExceptionMessage =
            "Only representatives of the organization can use the management panel.";

        public const string ManageOrganizationCoursesExceptionMessage =
            "Only representatives of the organization can manage the organization courses.";

        public const string EditOrganizationProfileExceptionMessage =
    "Only representatives of the organization can edit the organization profile.";


        public const string EditUserProfileExceptionMessage =
            "You are not allowed to modify the profiles of other users.";

        public const string ViewUserCoursesExceptionMessage =
    "You are not allowed to view other users courses.";

        public const string ViewUserOrganizationsExceptionMessage =
"You are not allowed to view other users organizations.";


        public const string ModifyArticleExceptionMessage = "You are not allowed to modify this article";
    }
}
