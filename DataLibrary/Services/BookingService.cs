using DataLibrary.Entities;
using DataLibrary.Repository;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

/// <summary>
/// Detta är service-lagret för en model-class. Här skapas "kopplingen" mellan service och repository.
/// Här pratar man med repistory-lagret och inte med databasen direkt. 
/// Här i finns även mindre/mer komplexa metoder. Vi kan också här blanda in flera olika class-modeller för störra metoder.
/// </summary>
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

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    public List<BookingModel> GetBookings() =>
        _bookingRepository.GetBookings().ToList();

    /// <summary>
    /// Metod som skickar till repository lagret att databasen ska sparas.
    /// </summary>
    public void Save() => _bookingRepository.Save();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    public BookingModel GetBookingByID(int? id)
    {
        var booking = _bookingRepository.GetBookingByID(id);
        return booking;
    }

    /// <summary>
    /// Metoden tar emot en modell av en specifik class och skickar den vidare till repository lagret som sedan lägger in den i databasen.
    /// </summary>
    /// <param name="booking">booking är ett objekt av en modell.</param>
    public void InsertBooking(BookingModel booking)
    {
        _bookingRepository.InsertBooking(booking);
    }

    /// <summary>
    /// Metod som enkelt kollar två int värden mot varandra. Används för at kolla om lediga platser är mindre än bokade platser. 
    /// In-värden beror på vad kunden skickar in och aktuella lediga platser i databasen.
    /// </summary>
    /// <returns>Returnerar true om det är mindre lediga platser kvar än vad kunden vill boka.</returns>
    public bool CheckAvailableSeats(int availableSeats, int bookedTickets)
    {
        //Checks if Saloon is full
        if (availableSeats < bookedTickets)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Metod som tar fram en mer detaljerad lista. Inkluderar ActiveMovieModel, MovieModel och SaloonModel för att få fram exakt värde ur tabellen.
    /// Används för att få index-värden. Denna metod representerar en enkel join av olika Models
    /// </summary>
    /// <returns>Returnerar allt i form av en IEnumerable</returns>
    public List<BookingModel> GetDetailedBookingList()
    {
        var detailedBookingList = _repositoryContext.BookingModels
            .Include(a => a.ActiveMovieModel)
            .ThenInclude(m => m.MovieModel)
            .Include(s => s.ActiveMovieModel)
            .ThenInclude(b => b.SaloonModel);
        return detailedBookingList.ToList();
    }
    
    /// <summary>
    /// Metod som tar emot ett int värde och skickar det vidare till repository lagret för borttagning. 
    /// </summary>
    /// <param name="bookingId">int värde som representerar index av det objekt man vill ta bort.</param>
    public void DeleteBooking(int bookingId)
    {
        _bookingRepository.DeleteBooking(bookingId);
    }
}
