using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;
/// <summary>
/// En model-class som hanterar Saloonger och dess information. 
/// </summary>
public class SaloonModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Display(Name = "Saloon")]
    public string Name { get; set; }
    public int NumberOfSeats { get; set; }
    [Display(Name = "Available Seats")]
    public int AvailableSeats { get; set; }
    public ICollection<SeatModel> Seats { get; set; }

    public SaloonModel()
    {

    }

    public SaloonModel(string name, int numberOfSeats)
    {
        Name = name;
        NumberOfSeats = numberOfSeats;
        AvailableSeats = numberOfSeats;
    }
}
