using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public MovieRepository(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void DeleteMovie(int movieId)
        {
            MovieModel movie = _repositoryContext.MovieModels.Find(movieId);
            _repositoryContext.MovieModels.Remove(movie);
        }

        public MovieModel GetMovieByID(int movieId)
        {
            return _repositoryContext.MovieModels.Find(movieId);
        }

        public IEnumerable<MovieModel> GetMovies()
        {
            return _repositoryContext.MovieModels;
        }

        public void InsertMovie(MovieModel movie)
        {
            _repositoryContext.MovieModels.Add(movie);
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public void UpdateMovie(MovieModel movie)
        {
            _repositoryContext.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repositoryContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
