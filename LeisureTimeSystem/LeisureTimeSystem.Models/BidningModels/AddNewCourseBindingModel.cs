using System.Collections.Generic;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class AddNewCourseBindingModel
    {
        public int OrganizationId { get; set; }

        public int DisciplineId { get; set; }

        public NewCourseBindingModel Course { get; set; }

    }
}
