using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	public class LocationsTypeController : ControllerBase
	{
		private readonly SiteContext _db;

		public LocationsTypeController(SiteContext db)
		{
			this._db = db;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_db.LocationTypes.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var locationType = _db.LocationTypes.Find(id);
			if (locationType == null)
				return NotFound();

			return Ok(locationType);
		}

		[HttpPost]
		public IActionResult Post([FromBody] LocationType locationType)
		{
			_db.LocationTypes .Add(locationType);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetById),
				new { id = locationType.LocTypeId },
				locationType
				);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, LocationType locationType)
		{
			if (id != locationType.LocTypeId) return BadRequest();
			_db.Entry(locationType).State = EntityState.Modified;
			try
			{
				_db.SaveChanges();
			}
			catch
			{
				if (_db.LocationTypes.Find(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var locationTypes = _db.LocationTypes.Find(id);
			if (locationTypes == null)
				return NotFound();

			_db.Remove(locationTypes);
			_db.SaveChanges();

			return Ok(locationTypes);
		}
	}
}
