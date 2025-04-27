using System;
namespace Kollegeni.Models
{
	public class Booking
	{
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

		public int BookingId { get; set; }

        public Booking()
		{
		}
	}
}

