using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IBookingService
{
    List<BookingModel> GetBookings();
    List<BookingModel> GetDetailedBookingList();
    BookingModel GetBookingByID(int? id);
    bool CheckAvailableSeats(int availableSeats, int bookedTickets);
    void InsertBooking(BookingModel booking);
    void DeleteBooking(int bookingId);
    void Save();
}
