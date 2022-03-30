using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IActiveMovieService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Enkelt så skickar vi en förfrågan om att "Ge oss allt du har på denna modellen"
    /// </summary>
    /// <returns>Returnerar allt i en lista</returns>
    List<ActiveMovieModel> GetActiveMovies();

    /// <summary>
    /// Metod som tar fram en mer detaljerad lista. Inkluderar ActiveMovieModel, MovieModel och SaloonModel för att få fram exakt värde ur tabellen.
    /// Används för att få index-värden. Denna metod representerar en enkel join av olika Models
    /// </summary>
    /// <returns>Returnerar allt i form av en IEnumerable</returns>
    IEnumerable<ActiveMovieModel> GetDetailedActiveMovieList();

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    ActiveMovieModel GetActiveMovieByID(int? id);
}
