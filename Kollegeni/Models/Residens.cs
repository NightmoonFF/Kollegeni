using Kollegeni.Models;
namespace Kollegeni.Models;
public class Residens
{
    public int Id { get; set; }
    public int Størrelse { get; set; }
    public string Adresse { get; set; }

    public virtual ICollection<BrugerResidens> BrugerResidenser { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<Booking> Bookinger { get; set; }
}

public class BrugerResidens
{
    public int BrugerId { get; set; }
    public int ResidensId { get; set; }

    public virtual Bruger Bruger { get; set; }
    public virtual Residens Residens { get; set; }
}
