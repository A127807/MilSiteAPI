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

	//The following statement applies this filter to all the action statements in this controller
	//[Version1DiscontinueResourceFilter]
	public class SpacePhotosController : ControllerBase
	{
		private readonly SiteContext _db;

		public SpacePhotosController(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public IActionResult Get()
		{

			return Ok(_db.SpacePhotos.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var spacePhotos = _db.SpacePhotos.Find(id);
			if (spacePhotos == null)
				return NotFound();

			return Ok(spacePhotos);
		}

		[HttpPost]
		public IActionResult Post([FromBody] SpacePhoto spacePhoto)
		{
			_db.SpacePhotos.Add(spacePhoto);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetById),
				new { id = spacePhoto.SpacePhotoId },
				spacePhoto
				);
		}

		[HttpPost]
		[Route("/api/v2/locations")]
		public IActionResult PostV2([FromBody] SpacePhoto spacePhoto)
		{
			_db.SpacePhotos.Add(spacePhoto);
			_db.SaveChanges();

			return Ok(spacePhoto);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, SpacePhoto spacePhoto)
		{
			if (id != spacePhoto.SpacePhotoId) return BadRequest();
			_db.Entry(spacePhoto).State = EntityState.Modified;
			try
			{
				_db.SaveChanges();
			}
			catch
			{
				if (_db.SpacePhotos.Find(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var spacePhoto = _db.SpacePhotos.Find(id);
			if (spacePhoto == null)
				return NotFound();

			_db.Remove(spacePhoto);
			_db.SaveChanges();

			return Ok(spacePhoto);
		}
	}
}
