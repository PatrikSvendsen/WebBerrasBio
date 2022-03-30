using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces
{
    /// <summary>
    /// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
    /// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
    /// </summary>
    public interface ITimeRepository : IDisposable
    {
        /// <summary>
        /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
        /// </summary>
        /// <returns>En IEnumerable med all information</returns>
        IEnumerable<TimeModel> GetTimes();
    }
}
