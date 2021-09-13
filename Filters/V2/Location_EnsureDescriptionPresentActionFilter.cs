using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MilSiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Filters.V2
{
	public class Location_EnsureDescriptionPresentActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var location = context.ActionArguments["location"] as Location;

			if (location != null && !location.ValidateDescription())
			{
				context.ModelState.AddModelError("Description", "Description is required.");
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}
