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
	[ApiVersion("1.0")]
	[ApiController]
	[Route("api/[controller]")]

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
		public async Task<IActionResult> Post([FromBody] Location location)
		{
			_db.Locations.Add(location);
			await _db.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById),
				new {id = location.LocId},
				location
				);
		}

		//[HttpPost]
		//[Route("/api/v2/locations")]
		//public async Task<IActionResult> PostV2([FromBody] Location location)
		//{
		//	_db.Locations.Add(location);
		//	await _db.SaveChangesAsync();

		//	return Ok(location);
		//}

		[HttpPut("{id}")]
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
