using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services;

/// <summary>
/// Detta är service-lagret för en model-class. Här skapas "kopplingen" mellan service och repository.
/// Här pratar man med repistory-lagret och inte med databasen direkt. 
/// Här i finns även mindre/mer komplexa metoder. Vi kan också här blanda in flera olika class-modeller för störra metoder.
/// </summary>
public class TimeService : ITimeService
{
    private readonly ITimeRepository _timeRepository;
    public TimeService(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i form av en lista</returns>
    public List<TimeModel> GetTimes() =>
        _timeRepository.GetTimes().ToList();
}
