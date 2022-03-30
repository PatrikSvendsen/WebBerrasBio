using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IBookingService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    List<BookingModel> GetBookings();

    /// <summary>
    /// Metod som tar fram en mer detaljerad lista. Inkluderar ActiveMovieModel, MovieModel och SaloonModel för att få fram exakt värde ur tabellen.
    /// Används för att få index-värden. Denna metod representerar en enkel join av olika Models
    /// </summary>
    /// <returns>Returnerar allt i form av en IEnumerable</returns>
    List<BookingModel> GetDetailedBookingList();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    BookingModel GetBookingByID(int? id);

    /// <summary>
    /// Metod som enkelt kollar två int värden mot varandra. Används för at kolla om lediga platser är mindre än bokade platser. 
    /// In-värden beror på vad kunden skickar in och aktuella lediga platser i databasen.
    /// </summary>
    /// <returns>Returnerar true om det är mindre lediga platser kvar än vad kunden vill boka.</returns>
    bool CheckAvailableSeats(int availableSeats, int bookedTickets);

    /// <summary>
    /// Metoden tar emot en modell av en specifik class och skickar den vidare till repository lagret som sedan lägger in den i databasen.
    /// </summary>
    /// <param name="booking">booking är ett objekt av en modell.</param>
    void InsertBooking(BookingModel booking);

    /// <summary>
    /// Metod som tar emot ett int värde och skickar det vidare till repository lagret för borttagning. 
    /// </summary>
    /// <param name="bookingId">int värde som representerar index av det objekt man vill ta bort.</param>
    void DeleteBooking(int bookingId);

    /// <summary>
    /// Metod som skickar till repository lagret att databasen ska sparas.
    /// </summary>
    void Save();
}
