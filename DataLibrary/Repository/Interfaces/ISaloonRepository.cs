using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

public interface ISaloonRepository : IDisposable
{
    IEnumerable<SaloonModel> GetSaloons();
    SaloonModel GetSaloonByID(int? saloonId);
    void Save();
}
