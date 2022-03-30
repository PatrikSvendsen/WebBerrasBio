using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

/// <summary>
/// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
/// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
/// </summary>
public interface ISeatRepository
{
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    IEnumerable<SeatModel> GetSeats();

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="seatId"></param>
    /// <returns>Returnerar funna objektet</returns>
    SeatModel GetSeatByID(int? seatId);

    /// <summary>
    /// Metod för att uppdatera befintlig rad/data i databasen. Använder specific class-typ i indata
    /// </summary>
    /// <param name="seat">Parametern är en samling med information av reprensativ-class type som man vill ändra</param>
    void UpdateSeat(SeatModel seat);

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    void Save();

    /// <summary>
    /// Metod för att hitta första tomma platsen i databasen.
    /// </summary>
    /// <returns>Returnerar ett object där propertyn "IsBooked" är false</returns>
    SeatModel FindEmptySeat();
}
