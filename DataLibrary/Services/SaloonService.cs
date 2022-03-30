using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services;

/// <summary>
/// Detta är service-lagret för en model-class. Här skapas "kopplingen" mellan service och repository.
/// Här pratar man med repistory-lagret och inte med databasen direkt. 
/// Här i finns även mindre/mer komplexa metoder. Vi kan också här blanda in flera olika class-modeller för störra metoder.
/// </summary>
public class SaloonService : ISaloonService
{
    private readonly ISaloonRepository _saloonRepository;
    public SaloonService(ISaloonRepository saloonRepository)
    {
        _saloonRepository = saloonRepository;
    }
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    public List<SaloonModel> GetSaloons() =>
        _saloonRepository.GetSaloons().ToList();

    public SaloonModel GetSaloonByID(int? id)
    {
        var saloon = _saloonRepository.GetSaloonByID(id);
        return saloon;
    }
    public void AdjustAvailableToBookedSeats(SaloonModel saloon, BookingModel booking)
    {
        saloon.AvailableSeats -= booking.BookedTickets;
    }
    public void AdjustAvailableBookedSeatsWhenDelete(SaloonModel saloon, BookingModel booking)
    {
        saloon.AvailableSeats += booking.BookedTickets;
    }
}
