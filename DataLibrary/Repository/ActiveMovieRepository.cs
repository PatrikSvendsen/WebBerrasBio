using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;

public class ActiveMovieRepository : IActiveMovieRepository
{
    private readonly RepositoryContext _repositoryContext;
    public ActiveMovieRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }

    public void DeleteActiveMovie(int activeMovieId)
    {
        ActiveMovieModel activeMovie = _repositoryContext.ActiveMovieModels.Find(activeMovieId);
        _repositoryContext.ActiveMovieModels.Remove(activeMovie);
    }

    public ActiveMovieModel GetActiveMovieByID(int? activeMovieId)
    {
        return _repositoryContext.ActiveMovieModels.Find(activeMovieId);
    }

    public IEnumerable<ActiveMovieModel> GetActiveMovies()
    {
        return _repositoryContext.ActiveMovieModels;
    }

    public void InsertActiveMovie(ActiveMovieModel activeMovie)
    {
        _repositoryContext.ActiveMovieModels.Add(activeMovie);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public void UpdateActiveMovie(ActiveMovieModel activeMovie)
    {
        _repositoryContext.Entry(activeMovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
