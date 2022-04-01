using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services;

/// <summary>
/// Detta är service-lagret för en model-class. Här skapas "kopplingen" mellan service och repository.
/// Här pratar man med repistory-lagret och inte med databasen direkt. 
/// Här i finns även mindre/mer komplexa metoder. Vi kan också här blanda in flera olika class-modeller för störra metoder.
/// </summary>
public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    public SeatService(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    public List<SeatModel> GetSeats() =>
        _seatRepository.GetSeats().ToList();

    /// <summary>
    /// Metod som skickar till repository lagret att databasen ska sparas.
    /// </summary>
    public void Save() => _seatRepository.Save();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="seatId">seatId representerar indexet på objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    public SeatModel GetSeatByID(int? seatId)
    {
        var seat = _seatRepository.GetSeatByID(seatId);
        return seat;
    }

    /// <summary>
    /// Metod som skickar en förfråga till repository lagret om att hitta första lediga plats och sedan skicka tillbaka det.
    /// Man kollar mot property "IsBooked". false/true
    /// </summary>
    /// <returns>Returnerar en tom seat</returns>
    public SeatModel FindEmptySeat()
    {
        return _seatRepository.FindEmptySeat();
    }

    /// <summary>
    /// Metod som tar emot antalet bokade platser i form av int och ett boknings id.
    /// Sedan används metoden FindEmptySeat för att hitta en ledig plats.
    /// </summary>
    public void UpdateSeat(int? bookedTickets, int bookingId)
    {
        for (int i = 1; i <= bookedTickets; i++)
        {
            var seatList = _seatRepository.FindEmptySeat();
            seatList.BookingModelId = bookingId;
            seatList.IsBooked = true;
            _seatRepository.Save();
        }
    }

    /// <summary>
    /// Metod som som tar emot en int och letar upp alla platser som har detta i sin property för BookingModelId.
    /// Värdena ändras sedan tillbaka till standard för att visa systemet att platsen är ledig och redo för ny bokning.
    /// Man kollar mot propertyn "BookingId"
    /// </summary>
    public void DeUpdateSeats(int bookingId)
    {
        var seats = _seatRepository.GetSeats()
                    .Where(x => x.BookingModelId == bookingId);
        foreach (var item in seats)
        {
            item.IsBooked = false;
            item.BookingModelId = -1;
        }
    }
}
