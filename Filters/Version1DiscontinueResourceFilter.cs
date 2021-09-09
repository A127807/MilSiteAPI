using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Filters
{
	public class Version1DiscontinueResourceFilter : Attribute, IResourceFilter
	{
		public void OnResourceExecuted(ResourceExecutedContext context)
		{
		}

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			if (context.HttpContext.Request.Path.Value.ToLower().Contains("v1"))
			{
				context.Result = new BadRequestObjectResult(
					new
					{
						Versioning = new[] { "This version of the API has expired. Please use the latest version" }
					}

				);
			}
		}
	}
}
