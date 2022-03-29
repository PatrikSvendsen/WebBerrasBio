using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository.Interfaces
{
    public interface IActiveMovieRepository : IDisposable
    {
        IEnumerable<ActiveMovieModel> GetActiveMovies();
        ActiveMovieModel GetActiveMovieByID(int? activeMovieId);
        void InsertActiveMovie(ActiveMovieModel activeMovie);
        void DeleteActiveMovie(int activeMovieId);
        void UpdateActiveMovie(ActiveMovieModel activeMovie);
        void Save();
    }
}
