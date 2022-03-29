using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

public interface ISeatRepository
{
    IEnumerable<SeatModel> GetSeats();
    SeatModel GetSeatByID(int? seatId);
    void InsertSeat(SeatModel seat);
    void DeleteSeat(int? seatId);
    void UpdateSeat(SeatModel seat);
    void Save();
    SeatModel FindEmptySeat();
}
