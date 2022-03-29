using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;

namespace DataLibrary.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public SeatRepository(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void DeleteSeat(int? seatId)
        {
            SeatModel seat = _repositoryContext.SeatModels.Find(seatId);
            _repositoryContext.SeatModels.Remove(seat);
        }

        public SeatModel GetSeatByID(int? movieId)
        {
            return _repositoryContext.SeatModels.Find(movieId);
        }

        public IEnumerable<SeatModel> GetSeats()
        {
            return _repositoryContext.SeatModels;
        }

        public void InsertSeat(SeatModel seat)
        {
            _repositoryContext.SeatModels.Add(seat);
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public void UpdateSeat(SeatModel seat)
        {
            _repositoryContext.Entry(seat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public SeatModel FindEmptySeat()
        {
            var seatToUpdate = _repositoryContext.SeatModels.First(x => x.IsBooked == false);
            return seatToUpdate;
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
}
