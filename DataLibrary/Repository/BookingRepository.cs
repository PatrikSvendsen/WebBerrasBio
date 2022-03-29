using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly RepositoryContext _repositoryContext;
    public BookingRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }

    public void DeleteBooking(int bookingID)
    {
        BookingModel booking = _repositoryContext.BookingModels.Find(bookingID);
        _repositoryContext.BookingModels.Remove(booking);
    }

    public BookingModel GetBookingByID(int? bookingId)
    {
        return _repositoryContext.BookingModels.Find(bookingId);
    }

    public IEnumerable<BookingModel> GetBookings()
    {
        return _repositoryContext.BookingModels;
    }

    public void InsertBooking(BookingModel booking)
    {
        _repositoryContext.BookingModels.Add(booking);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public void UpdateBooking(BookingModel booking)
    {
        _repositoryContext.Entry(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _repositoryContext.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
