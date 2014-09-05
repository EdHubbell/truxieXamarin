using System;

namespace truxie.Shared
{
	public class VendorEvent
	{
		public VendorEvent ()
		{
		}

		public Vendor Vendor { get; set; } 

		public VendorLocation VendorLocation { get; set; }

		public DateTime EventStartDateTime { get; set; } 
		public DateTime EventEndDateTime { get; set; }

	}
}



