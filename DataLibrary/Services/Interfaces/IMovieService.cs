using DataLibrary.Entities;

namespace DataLibrary.Services.Interfaces;

public interface IMovieService
{
    MovieModel GetMovieById(int? id);
}
