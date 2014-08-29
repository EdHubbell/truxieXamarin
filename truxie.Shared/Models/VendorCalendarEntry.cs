using System;

namespace truxie.Shared
{
	public class VendorCalendarEntry
	{
		public VendorCalendarEntry ()
		{
		}

		public string ImageUrl { get; set; }
		public string VendorName { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }

	}
}

