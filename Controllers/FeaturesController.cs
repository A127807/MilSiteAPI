using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FeaturesController : ControllerBase
	{

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Reading all Locations Features ");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Locations Feature #{id}.");
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok("Creating a Locations Features");
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update a Locations Features #{id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted a Locations Features #{id}.");
		}
	}
}

