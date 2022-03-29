using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;

public class SaloonRepository : ISaloonRepository
{
    private readonly RepositoryContext _repositoryContext;
    public SaloonRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }

    public SaloonModel GetSaloonByID(int? saloonId)
    {
        return _repositoryContext.SaloonModels.Find(saloonId);
    }

    public IEnumerable<SaloonModel> GetSaloons()
    {
        return _repositoryContext.SaloonModels;
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
