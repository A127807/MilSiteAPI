using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MilSiteAPI.Filters;
using MilSiteDataStore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI
{
	public class Startup
	{
		private readonly IWebHostEnvironment _env;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public Startup(IWebHostEnvironment env)
		{
			this._env = env;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			if (_env.IsDevelopment())
			{
				services.AddDbContext<SiteContext>(options =>
				{
					options.UseInMemoryDatabase("Site");
				});
			}
			services.AddControllers();

			//The following statement adds a filter to all controllers
			//services.AddControllers(options =>
			//{
			//	options.Filters.Add<Version1DiscontinueResourceFilter>();
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SiteContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				//Create in-memory database for dev environment
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
