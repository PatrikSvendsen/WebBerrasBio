using DataLibrary.Entities;
using DataLibrary.Repository;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly RepositoryContext _repositoryContext;

    public BookingService(IBookingRepository bookingRepository,
        RepositoryContext repositoryContext)
    {
        _bookingRepository = bookingRepository;
        _repositoryContext = repositoryContext;
    }

    public List<BookingModel> GetBookings() =>
        _bookingRepository.GetBookings().ToList();
    public void Save() => _bookingRepository.Save();

    public BookingModel GetBookingByID(int? id)
    {
        var booking = _bookingRepository.GetBookingByID(id);
        return booking;
    }
    public void InsertBooking(BookingModel booking)
    {
        _bookingRepository.InsertBooking(booking);
    }
    public bool CheckAvailableSeats(int availableSeats, int bookedTickets)
    {
        //Checks if Saloon is full
        if (availableSeats < bookedTickets)
        {
            return true;
        }
        return false;
    }
    public List<BookingModel> GetDetailedBookingList()
    {
        var detailedBookingList = _repositoryContext.BookingModels
            .Include(a => a.ActiveMovieModel)
            .ThenInclude(m => m.MovieModel)
            .Include(s => s.ActiveMovieModel)
            .ThenInclude(b => b.SaloonModel);
        return detailedBookingList.ToList();
    }
    public void DeleteBooking(int bookingId)
    {
        _bookingRepository.DeleteBooking(bookingId);
    }

}
