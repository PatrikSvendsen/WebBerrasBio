using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;
/// <summary>
/// Ett repository lager för en model-class. Här skapas en enskild kopplning till DbContext/RepositoryContext. 
/// Här finns alla metoder/logiker som pratar direkt med databasen. Alltså ingen model-class har en kopplning hit. 
/// Denna ärver av motsvarade model-class-interface för enklare injencering.
/// Detta är repository-lagret. Här tas en förfråga emot från service-lagret som sedan hanteras vidare mot databasen.
/// </summary>
public class TimeRepository : ITimeRepository
{
    private readonly RepositoryContext _repositoryContext;
    public TimeRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>En IEnumerable med all information</returns>
    public IEnumerable<TimeModel> GetTimes()
    {
        return _repositoryContext.TimeModels;
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
