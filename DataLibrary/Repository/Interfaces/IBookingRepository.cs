using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

/// <summary>
/// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
/// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
/// </summary>
public interface IBookingRepository : IDisposable
{
    /// <summary> 
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    IEnumerable<BookingModel> GetBookings();

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="bookingId"></param>
    /// <returns>Returnerar funna objektet</returns>
    BookingModel GetBookingByID(int? bookingId);

    /// <summary>
    /// Metod som tar emot data i form av en speciell class-typ och lägger sedan in den i databasen.
    /// </summary>
    /// <param name="booking">Parametern är en samling med information av reprensativ-class type</param>
    void InsertBooking(BookingModel booking);

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns. Finns det tas det bort från databasen.
    /// </summary>
    /// <param name="bookingID"></param>
    void DeleteBooking(int bookingId);

    /// <summary>
    /// Metod för att uppdatera befintlig rad/data i databasen. Använder specific class-typ i indata
    /// </summary>
    /// <param name="booking">Parametern är en samling med information av reprensativ-class type som man vill ändra</param>
    void UpdateBooking(BookingModel booking);

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    void Save();
}
