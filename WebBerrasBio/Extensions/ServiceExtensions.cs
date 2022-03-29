using DataLibrary.Repository;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services;
using DataLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebBerrasBio.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,
    IConfiguration configuration) =>
    services.AddDbContext<RepositoryContext>(opts =>
    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //-----------|DbContext
        services.AddScoped<RepositoryContext>();
        //-----------|Repositories
        services.AddTransient<IActiveMovieRepository, ActiveMovieRepository>();
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        services.AddTransient<ITimeRepository, TimeRepository>();
        services.AddTransient<ISaloonRepository, SaloonRepository>();
        services.AddTransient<ISeatRepository, SeatRepository>();
        //-----------|Services
        services.AddTransient<IActiveMovieService, ActiveMovieService>();
        services.AddTransient<IMovieService, MovieService>();
        services.AddTransient<IBookingService, BookingService>();
        services.AddTransient<ITimeService, TimeService>();
        services.AddTransient<ISaloonService, SaloonService>();
        services.AddTransient<ISeatService, SeatService>();
    }
}
