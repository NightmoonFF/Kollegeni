using Kollegeni.Models;
namespace Kollegeni.Models;
public class Residency
{
    public int Id { get; set; }
    // public int Størrelse { get; set; }
    public string Address { get; set; }

    public virtual ICollection<UserResidence> UserResidencies { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
}

public class UserResidence
{
    public int UserId { get; set; }
    public int ResidenceId { get; set; }

    public virtual User User { get; set; }
    public virtual Residency Residency { get; set; }
}
