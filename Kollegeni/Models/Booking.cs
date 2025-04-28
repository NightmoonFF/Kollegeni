using System.ComponentModel.DataAnnotations;

namespace Kollegeni.Models;
public class Booking
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Starttidspunkt")]
    [DataType(DataType.DateTime)]
    public DateTime Starttidspunkt { get; set; }

    [Required]
    [Display(Name = "Sluttidspunkt")]
    [DataType(DataType.DateTime)]
    public DateTime Sluttidspunkt { get; set; }

    public int FælleslokaleId { get; set; }
    public int ResidensId { get; set; }

    public virtual Fælleslokale Fælleslokale { get; set; }
    public virtual Residens Residens { get; set; }

}