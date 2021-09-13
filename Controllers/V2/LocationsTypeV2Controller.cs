using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilSiteAPI.Filters.V2;
using MilSiteCore.Models;
using MilSiteDataStore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers.V2
{
	[ApiVersion("2.0")]
	[ApiController]
	[Route("api/v2/[controller]")]
	public class LocationsTypeV2Controller : ControllerBase
	{
		private readonly SiteContext _db;

		public LocationsTypeV2Controller(SiteContext db)
		{
			this._db = db;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _db.LocationTypes.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var locationType = await _db.LocationTypes.FindAsync(id);
			if (locationType == null)
				return NotFound();

			return Ok(locationType);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] LocationType locationType)
		{
			_db.LocationTypes .Add(locationType);
			await _db.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById),
				new { id = locationType.LocTypeId },
				locationType
				);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, LocationType locationType)
		{
			if (id != locationType.LocTypeId) return BadRequest();
			_db.Entry(locationType).State = EntityState.Modified;
			try
			{
				await _db.SaveChangesAsync();
			}
			catch
			{
				if (await _db.LocationTypes.FindAsync(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var locationTypes = await _db.LocationTypes.FindAsync(id);
			if (locationTypes == null)
				return NotFound();

			_db.Remove(locationTypes);
			await _db.SaveChangesAsync();

			return Ok(locationTypes);
		}
	}
}
