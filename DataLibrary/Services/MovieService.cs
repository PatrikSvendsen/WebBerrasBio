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
public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    /// <summary>
    /// Här kallar vi på metoden som finner sig i repository lagret. Vi skickar en förfrågan om att leta upp ett objekt på Id.
    /// </summary>
    /// <param name="id">Id representerar det objekt man vill metoden ska leta fram</param>
    /// <returns>Om det finns något på Id så kommer det att returneras</returns>
    public MovieModel GetMovieById(int? id)
    {
        var movie = _movieRepository.GetMovieById(id);
        return movie;
    }
}