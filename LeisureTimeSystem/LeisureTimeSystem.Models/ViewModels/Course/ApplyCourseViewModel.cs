﻿using System;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class ApplyCourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string OrganizationName { get; set; }
    }
}