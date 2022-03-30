using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface ITimeService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i form av en lista</returns>
    List<TimeModel> GetTimes();
}
