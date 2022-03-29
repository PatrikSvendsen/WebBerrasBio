using DataLibrary.Entities;
using DataLibrary.Repository;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services
{
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

        public List<ActiveMovieModel> GetActiveMovies() =>
            _activeMovieRepository.GetActiveMovies().ToList();

        public IEnumerable<ActiveMovieModel> GetDetailedActiveMovieList()
        {
            var detailedList = _repositoryContext.ActiveMovieModels
                .Include(m => m.MovieModel)
                .Include(s => s.SaloonModel)
                .Include(t => t.TimeModel);

            return detailedList;
        }

        public ActiveMovieModel GetActiveMovieByID(int? id)
        {
            var activeMovie = _activeMovieRepository.GetActiveMovieByID(id);
            return activeMovie;
        }
    }
}