using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ContactsController : ControllerBase
	{

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Reading all Locations Contacts ");
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok($"Reading a Locations Contacts #{id}.");
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok("Creating a Locations Contacts");
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update a Locations Contacts #{id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted a Locations Contacts #{id}.");
		}
	}
}
