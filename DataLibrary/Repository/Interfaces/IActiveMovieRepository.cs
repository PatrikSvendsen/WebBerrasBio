using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

/// <summary>
/// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
/// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
/// </summary>
public interface IActiveMovieRepository : IDisposable
{
    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="activeMovieId"></param>
    /// <returns>Returnerar funna objektet</returns>
    IEnumerable<ActiveMovieModel> GetActiveMovies();

    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    ActiveMovieModel GetActiveMovieByID(int? activeMovieId);

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    void Save();
}
