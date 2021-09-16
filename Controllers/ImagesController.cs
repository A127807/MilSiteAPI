using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Controllers
{
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

		//The following statement applies this filter to all the action statements in this controller
		//[Version1DiscontinueResourceFilter]
		public class ImagesController : ControllerBase
		{
			private readonly SiteContext _db;

			public ImagesController(SiteContext db)
			{
				this._db = db;
			}
			[HttpGet]
			public async Task<IActionResult> Get()
			{

				return Ok(await _db.Images.ToListAsync());
			}

			[HttpGet("{id}")]
			public async Task<IActionResult> GetById(int id)
			{
				var images = await _db.Images.FindAsync(id);
				if (images == null)
					return NotFound();

				return Ok(images);
			}

			[HttpPost]
			public async Task<IActionResult> Post([FromBody] Image image)
			{
				_db.Images.Add(image);
				await _db.SaveChangesAsync();

				return CreatedAtAction(nameof(GetById),
					new { id = image.ImageId },
					image
					);
			}

			//[HttpPost]
			//[Route("/api/v2/locations")]
			//public async Task<IActionResult> PostV2([FromBody] Image image)
			//{
			//	_db.Images.Add(image);
			//	await _db.SaveChangesAsync();

			//	return Ok(image);
			//}

			[HttpPut("{id}")]
			public async Task<IActionResult> Put(int id, Image image)
			{
				if (id != image.ImageId) return BadRequest();
				_db.Entry(image).State = EntityState.Modified;
				try
				{
					await _db.SaveChangesAsync();
				}
				catch
				{
					if (await _db.Images.FindAsync(id) == null)
						return NotFound();
				}
				return NoContent();
			}

			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(int id)
			{
				var image = await _db.Images.FindAsync(id);
				if (image == null)
					return NotFound();

				_db.Remove(image);
				await _db.SaveChangesAsync();

				return Ok(image);
			}
		}
	}
}
