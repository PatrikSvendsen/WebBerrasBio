using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface ISeatService
{
    List<SeatModel> GetSeats();
    SeatModel GetSeatByID(int? id);
    void UpdateSeat(int? bookedTickets, int bookingId);
    void DeUpdateSeats(int id);
    SeatModel FindEmptySeat();
    void Save();
    
}
