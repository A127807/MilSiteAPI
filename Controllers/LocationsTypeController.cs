using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class LocationsTypeController : ControllerBase
	{

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Reading all Location Type Type");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Location Type #{id}.");
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok("Creating a Location Type");
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update Location Type #{id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted Location Type #{id}.");
		}
	}
}
