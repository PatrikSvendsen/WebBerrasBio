using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface ISaloonService
{
    List<SaloonModel> GetSaloons();
    SaloonModel GetSaloonByID(int? id);
    void AdjustAvailableToBookedSeats(SaloonModel saloon, BookingModel booking);
    void AdjustAvailableBookedSeatsWhenDelete(SaloonModel saloon, BookingModel booking);
}
