using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services;

public class SaloonService : ISaloonService
{
    private readonly ISaloonRepository _saloonRepository;
    public SaloonService(ISaloonRepository saloonRepository)
    {
        _saloonRepository = saloonRepository;
    }

    public List<SaloonModel> GetSaloons() =>
        _saloonRepository.GetSaloons().ToList();

    public SaloonModel GetSaloonByID(int? id)
    {
        var saloon = _saloonRepository.GetSaloonByID(id);
        return saloon;
    }
    public void AdjustAvailableToBookedSeats(SaloonModel saloon, BookingModel booking)
    {
        saloon.AvailableSeats -= booking.BookedTickets;
    }
    public void AdjustAvailableBookedSeatsWhenDelete(SaloonModel saloon, BookingModel booking)
    {
        saloon.AvailableSeats += booking.BookedTickets;
    }
}
