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
public class ActiveMovieService : IActiveMovieService
{
    private readonly IActiveMovieRepository _activeMovieRepository;
    private readonly RepositoryContext _repositoryContext;

    public ActiveMovieService(IActiveMovieRepository activeMovieRepository,
        RepositoryContext repositoryContext)
    {
        _activeMovieRepository = activeMovieRepository;
        _repositoryContext = repositoryContext;
    }

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    public List<ActiveMovieModel> GetActiveMovies() =>
        _activeMovieRepository.GetActiveMovies().ToList();

    /// <summary>
    /// Metod som tar fram en mer detaljerad lista. Inkluderar ActiveMovieModel, MovieModel och SaloonModel för att få fram exakt värde ur tabellen.
    /// Används för att få index-värden. Denna metod representerar en enkel join av olika Models
    /// </summary>
    /// <returns>Returnerar allt i form av en IEnumerable</returns>
    public IEnumerable<ActiveMovieModel> GetDetailedActiveMovieList()
    {
        var detailedList = _repositoryContext.ActiveMovieModels
            .Include(m => m.MovieModel)
            .Include(s => s.SaloonModel)
            .Include(t => t.TimeModel);

        return detailedList;
    }

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    public ActiveMovieModel GetActiveMovieByID(int? id)
    {
        var activeMovie = _activeMovieRepository.GetActiveMovieByID(id);
        return activeMovie;
    }
}
