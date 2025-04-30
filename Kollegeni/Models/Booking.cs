using System.ComponentModel.DataAnnotations;

namespace Kollegeni.Models;
public class Booking
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "StartTime")]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [Required]
    [Display(Name = "EndTime")]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    public int RoomId { get; set; }
    public int ResidencyId { get; set; } // Relation til Residency

    public virtual Room Room { get; set; }
    public virtual Residency Residency { get; set; } // Relation til Residency
}
