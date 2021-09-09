using MilSiteAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.ModelValidations
{
	public class Location_EnsureCreateDateLessThanUpdateDate: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var location = validationContext.ObjectInstance as Location;

			if(location != null && location.DateUpdated != null && location.DateUpdated != null)
			{
				if(location.DateCreated > location.DateUpdated)
				{
					return new ValidationResult("Date Updated must be greater then Date Created.");
				}
			}
			return ValidationResult.Success;
		}
	}
}
