using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface ISaloonService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    List<SaloonModel> GetSaloons();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    SaloonModel GetSaloonByID(int? id);

    /// <summary>
    /// Metod som ändrar ned värdet på en property beroende på vad som skickas in. Används för att hålla koll på antalet lediga platser i en salong.
    /// </summary>
    /// <param name="saloon">Här skickas en model in av SaloonModel. Tanken är att ta ut tomma platser</param>
    /// <param name="booking">Model av BookingModel tas emot och man plockar ut antalet bookade platser.</param>
    void AdjustAvailableToBookedSeats(SaloonModel saloon, BookingModel booking);

    /// <summary>
    /// Metod som ändrar upp värdet på en property beroende på vad som skickas in. Används för att hålla koll på antalet lediga platser i en salong.
    /// </summary>
    /// <param name="saloon">Här skickas en model in av SaloonModel. Tanken är att ta ut tomma platser</param>
    /// <param name="booking">Model av BookingModel tas emot och man plockar ut antalet bookade platser.</param>
    void AdjustAvailableBookedSeatsWhenDelete(SaloonModel saloon, BookingModel booking);
}
