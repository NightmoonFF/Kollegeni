using System;
namespace Kollegeni.Models
{
	public class Event
	{
		public DateTime StartTudspunkt { get; set; }
		public DateTime SlutTidspunkt { get; set; }
		public String Beskrivelse { get; set; }
		public String Navn { get; set; }
		public Event()
		{
		}
	}
}

