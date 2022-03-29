using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository.Interfaces
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<MovieModel> GetMovies();
        MovieModel GetMovieByID(int movieId);
        void InsertMovie(MovieModel movie);
        void DeleteMovie(int movieId);
        void UpdateMovie(MovieModel movie);
        void Save();
    }
}
