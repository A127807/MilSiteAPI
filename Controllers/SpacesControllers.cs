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
	[Route("api/[controller]")]

	//The following statement applies this filter to all the action statements in this controller
	//[Version1DiscontinueResourceFilter]
	public class SpacesController : ControllerBase
	{
		private readonly SiteContext _db;

		public SpacesController(SiteContext db)
		{
			this._db = db;
		}
		[HttpGet]
		public IActionResult Get()
		{

			return Ok(_db.Spaces.ToList());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var space = _db.Spaces.Find(id);
			if (space == null)
				return NotFound();

			return Ok(space);
		}

		[HttpGet]
		[Route("/api/v1/spaces/{sid}/spacephotos")]
		public IActionResult GetPhotosForSpaces(int sid)
		{
			var photos = _db.Images.Where(p => p.SpaceId == sid).ToList();
			if (photos == null || photos.Count <= 0)
				return NotFound();

			return Ok(photos);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Space space)
		{
			_db.Spaces.Add(space);
			_db.SaveChanges();

			return CreatedAtAction(nameof(GetById),
				new { id = space.SpaceId },
				space
				);
		}

		[HttpPost]
		[Route("/api/v2/locations")]
		public IActionResult PostV2([FromBody] Space space)
		{
			_db.Spaces.Add(space);
			_db.SaveChanges();

			return Ok(space);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, Space space)
		{
			if (id != space.SpaceId) return BadRequest();
			_db.Entry(space).State = EntityState.Modified;
			try
			{
				_db.SaveChanges();
			}
			catch
			{
				if (_db.Spaces.Find(id) == null)
					return NotFound();
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var space = _db.Spaces.Find(id);
			if (space == null)
				return NotFound();

			_db.Remove(space);
			_db.SaveChanges();

			return Ok(space);
		}
	}
}
