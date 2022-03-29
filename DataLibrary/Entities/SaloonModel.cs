using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities;

public class SaloonModel
{
    public int Id { get; set; }
    [Display(Name = "Saloon")]
    public string Name { get; set; }
    public int NumberOfSeats { get; set; }
    [Display(Name = "Available Seats")]
    public int AvailableSeats { get; set; } // Går detta att förbättra? 

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
