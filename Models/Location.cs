using MilSiteAPI.ModelValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilSiteAPI.Models
{
	public class Location
	{
		public int LocId { get; set; }

		[Required]
		public string LocName { get; set; }
		public int? MaxStay { get; set; }

		[Required]
		[Location_NumSpacesGreaterThan0]
		public int? NumSpaces { get; set; }

		[Required]
		public DateTime? DateCreated { get; set; }

		[Location_EnsureCreateDateLessThanUpdateDate]
		public DateTime? DateUpdated { get; set; }
	}
}
