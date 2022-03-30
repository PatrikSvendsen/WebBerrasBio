using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;
/// <summary>
/// Ett repository lager för en model-class. Här skapas en enskild kopplning till DbContext/RepositoryContext. 
/// Här finns alla metoder/logiker som pratar direkt med databasen. Alltså ingen model-class har en kopplning hit. 
/// Denna ärver av motsvarade model-class-interface för enklare injencering.
/// Detta är repository-lagret. Här tas en förfråga emot från service-lagret som sedan hanteras vidare mot databasen.
/// </summary>
public class ActiveMovieRepository : IActiveMovieRepository
{
    private readonly RepositoryContext _repositoryContext;
    public ActiveMovieRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }
    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="activeMovieId"></param>
    /// <returns>Returnerar funna objektet</returns>
    public ActiveMovieModel GetActiveMovieByID(int? activeMovieId)
    {
        return _repositoryContext.ActiveMovieModels.Find(activeMovieId);
    }
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    public IEnumerable<ActiveMovieModel> GetActiveMovies()
    {
        return _repositoryContext.ActiveMovieModels;
    }
    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    private bool disposed = false;
    /// <summary>
    /// Metod som släpper/frigör all koppling mot databasen.
    /// </summary>
    /// <param name="disposing">bool</param>
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
