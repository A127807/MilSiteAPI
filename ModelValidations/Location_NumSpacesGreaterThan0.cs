using MilSiteAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.ModelValidations
{
	public class Location_NumSpacesGreaterThan0 : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var location = validationContext.ObjectInstance as Location;

			if(location != null && location.NumSpaces != null)
			{
				if (location.NumSpaces < 1)
				{
					return new ValidationResult("Number of Spaces Cannot Be Less Than One");
				}
			}
			return ValidationResult.Success;
		}
	}
}
