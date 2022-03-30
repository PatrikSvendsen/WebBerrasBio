using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository;
/// <summary>
/// Ett repository lager för en model-class. Här skapas en enskild kopplning till DbContext/RepositoryContext. 
/// Här finns alla metoder/logiker som pratar direkt med databasen. Alltså ingen model-class har en kopplning hit. 
/// Denna ärver av motsvarade model-class-interface för enklare injencering.
/// Detta är repository-lagret. Här tas en förfråga emot från service-lagret som sedan hanteras vidare mot databasen.
/// </summary>
public class SeatRepository : ISeatRepository
{
    private readonly RepositoryContext _repositoryContext;
    public SeatRepository(RepositoryContext repositoryContext)
    {
        this._repositoryContext = repositoryContext;
    }
    /// <summary>
    /// Metod som tar emot ett int värde och kollar om det finns i databasen.
    /// </summary>
    /// <param name="seatId"></param>
    /// <returns>Returnerar funna objektet</returns>
    public SeatModel GetSeatByID(int? seatId)
    {
        return _repositoryContext.SeatModels.Find(seatId);
    }
    /// <summary>
    /// Metod som på förfrågan tar fram all data från databasen och lagrar det i form av IEnumerable
    /// </summary>
    /// <returns>Returnerar en IEnumerable med all information</returns>
    public IEnumerable<SeatModel> GetSeats()
    {
        return _repositoryContext.SeatModels;
    }
    /// <summary>
    /// Metod för att uppdatera befintlig rad/data i databasen. Använder specific class-typ i indata
    /// </summary>
    /// <param name="seat">Parametern är en samling med information av reprensativ-class type som man vill ändra</param>
    public void UpdateSeat(SeatModel seat)
    {
        _repositoryContext.Entry(seat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
    /// <summary>
    /// Metod som sparar ändringar gjorda mot databasen.
    /// </summary>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
    /// <summary>
    /// Metod för att hitta första tomma platsen i databasen.
    /// </summary>
    /// <returns>Returnerar ett object där propertyn "IsBooked" är false</returns>
    public SeatModel FindEmptySeat()
    {
        var seatToUpdate = _repositoryContext.SeatModels.First(x => x.IsBooked == false);
        return seatToUpdate;
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
