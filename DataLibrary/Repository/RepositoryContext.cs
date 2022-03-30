using DataLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Repository
{
    /// <summary>
    /// Detta är huvud-context classen. Här kopplas modelerna ihop till DbContext. 
    /// Enbart för EF och code-first approach.
    /// </summary>
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<BookingModel> BookingModels { get; set; }
        public DbSet<ActiveMovieModel> ActiveMovieModels { get; set; }
        public DbSet<MovieModel> MovieModels { get; set; }
        public DbSet<SaloonModel> SaloonModels { get; set; }
        public DbSet<SeatModel> SeatModels { get; set; }
        public DbSet<TimeModel> TimeModels { get; set; }
    }
}
