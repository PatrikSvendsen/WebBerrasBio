using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface ISeatService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    List<SeatModel> GetSeats();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="seatId">seatId representerar indexet på objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    SeatModel GetSeatByID(int? seatId);

    /// <summary>
    /// Metod som tar emot antalet bokade platser i form av int och ett boknings id.
    /// Sedan används metoden FindEmptySeat för att hitta en ledig plats.
    /// </summary>
    void UpdateSeat(int? bookedTickets, int bookingId);

    /// <summary>
    /// Metod som som tar emot en int och letar upp alla platser som har detta i sin property för BookingModelId.
    /// Värdena ändras sedan tillbaka till standard för att visa systemet att platsen är ledig och redo för ny bokning.
    /// Man kollar mot propertyn "BookingId"
    /// </summary>
    void DeUpdateSeats(int bookingId);

    /// <summary>
    /// Metod som skickar en förfråga till repository lagret om att hitta första lediga plats och sedan skicka tillbaka det.
    /// Man kollar mot property "IsBooked". false/true
    /// </summary>
    /// <returns>Returnerar en tom seat</returns>
    SeatModel FindEmptySeat();

    /// <summary>
    /// Metod som skickar till repository lagret att databasen ska sparas.
    /// </summary>
    void Save();
    
}
