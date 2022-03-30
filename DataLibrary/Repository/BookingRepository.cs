using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;
/// <summary>
/// Ett repository lager för en model-class. Här skapas en enskild kopplning till DbContext/RepositoryContext. 
/// Här finns alla metoder/logiker som pratar direkt med databasen. Alltså ingen model-class har en kopplning hit. 
/// Denna ärver av motsvarade model-class-interface för enklare injencering.
/// Detta är repository-lagret. Här tas en förfråga emot från service-lagret som sedan hanteras vidare mot databasen.
/// </summary>
public class BookingRepository : IBookingRepository
{
    private readonly RepositoryContext _repositoryContext;
    public BookingRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns. Finns det tas det bort från databasen.
    /// </summary>
    /// <param name="bookingID"></param>
    public void DeleteBooking(int bookingID)
    {
        BookingModel booking = _repositoryContext.BookingModels.Find(bookingID);
        _repositoryContext.BookingModels.Remove(booking);
    }

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns>Returnerar funna objektet</returns>
    public BookingModel GetBookingByID(int? bookingId)
    {
        return _repositoryContext.BookingModels.Find(bookingId);
    }

    /// <summary> 
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    public IEnumerable<BookingModel> GetBookings()
    {
        return _repositoryContext.BookingModels;
    }

    /// <summary>
    /// Metod som tar emot data i form av en speciell class-typ och lägger sedan in den i databasen.
    /// </summary>
    /// <param name="booking">Parametern är en samling med information av reprensativ-class type</param>
    public void InsertBooking(BookingModel booking)
    {
        _repositoryContext.BookingModels.Add(booking);
    }

    /// <summary>
    /// Metod för att uppdatera befintlig rad/data i databasen. Använder specific class-typ i indata
    /// </summary>
    /// <param name="booking">Parametern är en samling med information av reprensativ-class type som man vill ändra</param>
    public void UpdateBooking(BookingModel booking)
    {
        _repositoryContext.Entry(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    private bool disposed = false;
    /// <summary>
    /// Metod som släpper/frigör all koppling mot databasen.
    /// </summary>
    /// <param name="disposing">bool</param>
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
