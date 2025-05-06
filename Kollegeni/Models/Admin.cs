using System.Collections.Generic;

namespace Kollegeni.Models;
public class Admin //TODO: SKal nedarve fra User
{
    public int Id { get; set; } // Primær nøgle
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string attribute { get; set; }

    // Eventuelle relationer
    public virtual ICollection<Residency> ManagedResidencies { get; set; } // Eksempel på relation
}
