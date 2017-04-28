using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Enums;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class ChangeStatusApplicationViewModel
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
