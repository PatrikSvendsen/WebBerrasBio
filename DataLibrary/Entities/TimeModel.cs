using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;
/// <summary>
/// En model-class som enbart har visningstider 
/// </summary>
public class TimeModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Showtime")]
    public DateTime ShowTime { get; set; }
}
