﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Student;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class ManageRepresentativesViewModel
    {
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IEnumerable<RepresentativesStudentViewModel> CurrentRepresentatives { get; set; }
    }
}
