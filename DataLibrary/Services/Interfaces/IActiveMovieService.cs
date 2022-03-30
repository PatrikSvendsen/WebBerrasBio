using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IActiveMovieService
{
    List<ActiveMovieModel> GetActiveMovies();
    IEnumerable<ActiveMovieModel> GetDetailedActiveMovieList();
    ActiveMovieModel GetActiveMovieByID(int? id);
}
