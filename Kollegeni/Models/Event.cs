namespace Kollegeni.Models;
public class Event
{
    public int Id { get; set; }
    public DateTime Starttidspunkt { get; set; }
    public DateTime Sluttidspunkt { get; set; }
    public string Beskrivelse { get; set; }
    public string Navn { get; set; }

    public int ResidensId { get; set; }
    public virtual Residens Residens { get; set; }
}
