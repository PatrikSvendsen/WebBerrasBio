using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;

public class TimeRepository : ITimeRepository
{
    private readonly RepositoryContext _repositoryContext;
    public TimeRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }

    public TimeModel GetTimeByID(int timeId)
    {
        return _repositoryContext.TimeModels.Find(timeId);
    }

    public IEnumerable<TimeModel> GetTimes()
    {
        return _repositoryContext.TimeModels;
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
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
