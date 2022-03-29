using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces
{
    public interface ITimeRepository : IDisposable
    {
        IEnumerable<TimeModel> GetTimes();
        TimeModel GetTimeByID(int timeId);
        void Save();
    }
}
