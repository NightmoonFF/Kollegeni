namespace Kollegeni.Models;
public class Fælleslokale
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Beskrivelse { get; set; }

    public virtual ICollection<Booking> Bookinger { get; set; }
}
