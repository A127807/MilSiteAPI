using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MilSiteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is just a filtering example. I created it to use when I have another version of the API. This filter would allow
// me to validate some information, but only on a specfic version of the API. 

namespace MilSiteAPI.Filters
{
	public class Location_MaxStayMustBeGreaterThanZero :ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			var location = context.ActionArguments["location"] as Location;
			if(location != null && location.MaxStay != null)
			{
				if(location.MaxStay < 1)
				{
					context.ModelState.AddModelError("MaxStay", "Max Stay Value Cannot Be Less Than One");
					context.Result = new BadRequestObjectResult(context.ModelState);
				}
			}
		}
	}
}
