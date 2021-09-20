using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.QueryFilters
{
	public class LocationQueryFilter
	{
		public int? Id { get; set; }
		public string LocName { get; set; }
		public string Description { get; set; }
	}
}
