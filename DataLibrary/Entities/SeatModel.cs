namespace DataLibrary.Entities;

public class SeatModel
{
    public int Id { get; set; }
    public int InternalSeatNumber { get; set; }
    public bool IsBooked { get; set; } = false;
    public int SaloonModelId { get; set; }
    public int BookingModelId { get; set; } = -1;

    public SeatModel()
    {

    }
    public SeatModel(int interalSeatNumber, int saloonModelId)
    {
        InternalSeatNumber = interalSeatNumber;
        SaloonModelId = saloonModelId;
    }
}
