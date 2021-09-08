using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ImagesController : ControllerBase
	{

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Reading all Locations Images ");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Locations Images #{id}.");
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok("Creating a Locations Images");
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update a Locations Images #{id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted a Locations Images #{id}.");
		}
	}
}
