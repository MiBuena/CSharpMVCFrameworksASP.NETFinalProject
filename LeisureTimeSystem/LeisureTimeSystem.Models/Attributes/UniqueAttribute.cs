using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.Attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var valueAsInt = int.Parse(value.ToString());

        //    if(validationContext.)
        //    if (value as string == "Pesho")
        //    {
        //        return ValidationResult.Success;
        //    }
        //    return new ValidationResult("The passed value is not Pesho");
        //}

    }
}
