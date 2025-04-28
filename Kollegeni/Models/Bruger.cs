
namespace Kollegeni.Models;
public class Bruger
{
    public int Id { get; set; }
    public string Brugernavn { get; set; }
    public string KodeOrd { get; set; }
    public string Mail { get; set; }
    public string Sprog { get; set; }
    public string Avatar { get; set; }

    public virtual ICollection<BrugerResidens> BrugerResidenser { get; set; }
}

public class Beboer : Bruger
{
    // Eventuelle specielle egenskaber for beboere
}

public class Admin : Bruger
{
    public string Attribute { get; set; }
}
