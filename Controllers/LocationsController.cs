using Microsoft.AspNetCore.Mvc;
using MilSiteAPI.Filters;
using MilSiteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]

	//The following statement applies this filter to all the action statements in this controller
	//[Version1DiscontinueResourceFilter]
	public class LocationsController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Reading all Locations");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Location #{id}.");
		}

		[HttpPost]
		public IActionResult Post([FromBody] Location location)
		{
			return Ok(location);
		}

		[HttpPost]
		[Route("/api/v2/locations")]
		[Location_MaxStayMustBeGreaterThanZero]
		public IActionResult PostV2([FromBody] Location location)
		{
			return Ok(location);
		}

		[HttpPut]
		public IActionResult Put([FromBody] Location location)
		{
			return Ok(location);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted Location #{id}.");
		}
	}
}
