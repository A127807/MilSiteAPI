using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilSiteAPI.Filters;
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
	[Route("api/locations")]

	//The following statement applies this filter to all the action statements in this controller
	//[Version1DiscontinueResourceFilter]
	public class LocationsV2Controller : ControllerBase
	{
		private readonly SiteContext _db;

		public LocationsV2Controller(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{

			return Ok(await _db.Locations.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var location =  await _db.Locations.FindAsync(id);
			if (location == null)
				return NotFound();

			return Ok(location);
		}

		[HttpPost]
		[Location_EnsureDescriptionPresentActionFilter]
		public async Task<IActionResult> Post([FromBody] Location location)
		{
			_db.Locations.Add(location);
			await _db.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById),
				new {id = location.LocId},
				location
				);
		}

		[HttpPut("{id}")]
		[Location_EnsureDescriptionPresentActionFilter]
		public async Task<IActionResult> Put(int id,  Location location)
		{
			if (id != location.LocId) return BadRequest();
			_db.Entry(location).State = EntityState.Modified;
			try
			{
				await _db.SaveChangesAsync();
			}
			catch
			{
				if (await _db.Locations.FindAsync(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var location = await _db.Locations.FindAsync(id);
			if (location == null)
				return NotFound();

			_db.Remove(location);
			await _db.SaveChangesAsync();

			return Ok(location);
		}
	}
}
