using System;
namespace Kollegeni.Models
{
	public class Residens
	{
		public int Størrelse { get; set; }
		public String Adresse { get; set; }
		public List<Bruger> Beboere { get; set; }
		public Residens()
		{
			Beboere = new List<Bruger>;
		}
	}
}

