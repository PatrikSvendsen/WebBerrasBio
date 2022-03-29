using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;

public class TimeModel
{
    [Required]
    [Key]
    public int Id { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Showtime")]
    public DateTime ShowTime { get; set; }
}
