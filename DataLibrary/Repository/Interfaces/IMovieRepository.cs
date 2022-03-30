using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

/// <summary>
/// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
/// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
/// </summary>
public interface IMovieRepository : IDisposable
{
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    IEnumerable<MovieModel> GetMovies();

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns>Returnerar funna objektet</returns>
    MovieModel GetMovieByID(int movieId);

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    void Save();
}
