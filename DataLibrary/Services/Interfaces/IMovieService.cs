using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IMovieService
{
    List<MovieModel> GetMovies();
}
