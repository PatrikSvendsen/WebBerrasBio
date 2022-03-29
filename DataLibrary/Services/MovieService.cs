using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieModel> GetMovies() =>
            _movieRepository.GetMovies().ToList();
    }
}
