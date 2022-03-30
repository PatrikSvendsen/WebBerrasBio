using DataLibrary.Entities;

namespace DataLibrary.Repository.Interfaces;

/// <summary>
/// Interface-class för enskilda klasser. Mellanhand från repository till service lagret. 
/// Detta interface ärver dessutom från "IDisposable" som rensar/släpper/frigör resurser efter man använt dem.
/// </summary>
public interface ISaloonRepository : IDisposable
{
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    IEnumerable<SaloonModel> GetSaloons();

    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="saloonId"></param>
    /// <returns>Returnerar funna objektet</returns>
    SaloonModel GetSaloonByID(int? saloonId);

    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    void Save();
}
