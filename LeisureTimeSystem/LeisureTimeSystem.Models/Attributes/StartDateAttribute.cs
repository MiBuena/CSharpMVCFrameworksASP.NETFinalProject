﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Utils;

namespace LeisureTimeSystem.Models.Attributes
{
    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            DateTime minDate = DateTime.Now.AddYears(-Constants.StartCourseYearConstant);

            if (date >= minDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The course's start can not be more than {Constants.StartCourseYearConstant} years back in time.");
        }
    }

}
