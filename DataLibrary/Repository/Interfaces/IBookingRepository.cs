using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

public interface IBookingRepository : IDisposable
{
    IEnumerable<BookingModel> GetBookings();
    BookingModel GetBookingByID(int? bookingId);
    void InsertBooking(BookingModel booking);
    void DeleteBooking(int bookingId);
    void UpdateBooking(BookingModel booking);
    void Save();
}
