using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IMovieService
{
    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    MovieModel GetMovieById(int? id);
}
