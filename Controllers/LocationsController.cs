﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers 
{
	[ApiController]
	[Route("api/v1/[controller]")]
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
		public IActionResult Post()
		{
			return Ok("Creating a location");
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id)
		{
			return Ok($"Update Location #{id}.");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Ok($"Deleted Location #{id}.");
		}
	}
}
