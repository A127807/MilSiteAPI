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
	[Route("api/[controller]")]
	public class AmenitiesController : ControllerBase
	{

		private readonly SiteContext _db;

		public AmenitiesController(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{

			return Ok(await _db.Amenities.ToListAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var amenities = await _db.Amenities.FindAsync(id);
			if (amenities == null)
				return NotFound();

			return Ok(amenities);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Amenitie amentities)
		{
			_db.Amenities.Add(amentities);
			await _db.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById),
				new { id = amentities.AmID },
				amentities
				);
		}

		[HttpPost]
		[Route("/api/v2/amenities")]
		public async Task<IActionResult> PostV2([FromBody] Amenitie amentities)
		{
			_db.Amenities.Add(amentities);
			await _db.SaveChangesAsync();

			return Ok(amentities);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Amenitie amentities)
		{
			if (id != amentities.AmID) return BadRequest();
			_db.Entry(amentities).State = EntityState.Modified;
			try
			{
				await _db.SaveChangesAsync();
			}
			catch
			{
				if (await _db.Amenities.FindAsync(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var amenities = await _db.Amenities.FindAsync(id);
			if (amenities == null)
				return NotFound();

			_db.Remove(amenities);
			await _db.SaveChangesAsync();

			return Ok(amenities);
		}
	}
}