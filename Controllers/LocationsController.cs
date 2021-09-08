using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers 
{
	[ApiController]
	public class LocationsController: ControllerBase
	{
		[HttpGet]
		[Route("api/v1/locations")]
		public IActionResult Get()
		{
			return Ok("Reading all Locations");
		}

		[HttpGet]
		[Route("api/v1/locations/{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Location #{id}.");
		}

		[HttpPost]
		[Route("api/v1/locations")]
		public IActionResult Post()
		{
			return Ok("Creating a location");
		}

		[HttpPut]
		[Route("api/v1/locations/{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update Location #{id}.");
		}

		[HttpDelete]
		[Route("api/v1/locations/{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted Location #{id}.");
		}
	}
}
