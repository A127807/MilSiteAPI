using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilSiteAPI.Filters;
using MilSiteCore.Models;
using MilSiteDataStore.EF;
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
		private readonly SiteContext _db;

		public LocationsController(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public IActionResult Get()
		{

			return Ok(_db.Locations.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var location = _db.Locations.Find(id);
			if (location == null)
				return NotFound();

			return Ok(location);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Location location)
		{
			_db.Locations.Add(location);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetById),
				new {id = location.LocId},
				location
				);
		}

		[HttpPost]
		[Route("/api/v2/locations")]
		public IActionResult PostV2([FromBody] Location location)
		{
			_db.Locations.Add(location);
			_db.SaveChanges();

			return Ok(location);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id,  Location location)
		{
			if (id != location.LocId) return BadRequest();
			_db.Entry(location).State = EntityState.Modified;
			try
			{
				_db.SaveChanges();
			}
			catch
			{
				if (_db.Locations.Find(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var location = _db.Locations.Find(id);
			if (location == null)
				return NotFound();

			_db.Remove(location);
			_db.SaveChanges();

			return Ok(location);
		}
	}
}
