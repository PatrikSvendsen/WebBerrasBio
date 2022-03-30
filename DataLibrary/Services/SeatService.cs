using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;

    public SeatService(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public List<SeatModel> GetSeats() =>
        _seatRepository.GetSeats().ToList();
    public void Save() => _seatRepository.Save();

    public SeatModel GetSeatByID(int? id)
    {
        var seat = _seatRepository.GetSeatByID(id);
        return seat;
    }
    public SeatModel FindEmptySeat()
    {
        return _seatRepository.FindEmptySeat();
    }
    public void UpdateSeat(int? bookedTickets, int bookingId)
    {
        for (int i = 1; i <= bookedTickets; i++)
        {
            var seatList = _seatRepository.FindEmptySeat();
            seatList.BookingModelId = bookingId;
            seatList.IsBooked = true;
            _seatRepository.Save();     // Är detta optimalt? Ska man skippa att ha 
                                        // färdiga seats i tabellen och lägga till/
                                        // ta bort efter hand?
        }
    }
    public void DeUpdateSeats(int id)
    {
        var seats = _seatRepository.GetSeats()
                    .Where(x => x.BookingModelId == id);
        foreach (var item in seats)
        {
            item.IsBooked = false;
            item.BookingModelId = -1;
        }
    }
}
