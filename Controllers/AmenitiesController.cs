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
	public class AmenitiesController : ControllerBase
	{

		private readonly SiteContext _db;

		public AmenitiesController(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public IActionResult Get()
		{

			return Ok(_db.Amenities.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var amenities = _db.Amenities.Find(id);
			if (amenities == null)
				return NotFound();

			return Ok(amenities);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Amenitie amentities)
		{
			_db.Amenities.Add(amentities);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetById),
				new { id = amentities.AmID },
				amentities
				);
		}

		[HttpPost]
		[Route("/api/v2/amenities")]
		public IActionResult PostV2([FromBody] Amenitie amentities)
		{
			_db.Amenities.Add(amentities);
			_db.SaveChanges();

			return Ok(amentities);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, Amenitie amentities)
		{
			if (id != amentities.AmID) return BadRequest();
			_db.Entry(amentities).State = EntityState.Modified;
			try
			{
				_db.SaveChanges();
			}
			catch
			{
				if (_db.Amenities.Find(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var amenities = _db.Amenities.Find(id);
			if (amenities == null)
				return NotFound();

			_db.Remove(amenities);
			_db.SaveChanges();

			return Ok(amenities);
		}
	}
}