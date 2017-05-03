using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Utils;

namespace LeisureTimeSystem.Models.Attributes
{
    public class EndDateAttribute : ValidationAttribute
    {
  
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);

            DateTime maxDate = DateTime.Now.AddYears(Constants.EndCourseYearConstant);

            if (date <= maxDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"The course can not last  for more than {Constants.EndCourseYearConstant} years ahead in time.");
        }
    }
}
