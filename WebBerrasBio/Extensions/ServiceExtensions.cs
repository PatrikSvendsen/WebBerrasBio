using DataLibrary.Repository;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services;
using DataLibrary.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebBerrasBio.Extensions;

    /// <summary>
     ///        Class för att hantera olika services, istället för att fylla upp program.cs. 
     ///        Här scopar vi även context/db till datalibrary-biblioteket
     /// </summary>
public static class ServiceExtensions
{
    /// <summary>
    ///        Här fixar vi med connectionStrings
    /// </summary>
    public static void ConfigureSqlContext(this IServiceCollection services,
    IConfiguration configuration) =>
    services.AddDbContext<RepositoryContext>(opts =>
    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    /// <summary>
    ///         Här lägger vi till services för scoping och injecering av klasser. 
    ///         Använder dessutom AddTransient() som skapar ny koppling varje gång de blir frågade.
    /// </summary>
    public static void ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //-----------|  DbContext
        services.AddScoped<RepositoryContext>();
        //-----------|  Repositories
        services.AddTransient<IActiveMovieRepository, ActiveMovieRepository>();
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        services.AddTransient<ITimeRepository, TimeRepository>();
        services.AddTransient<ISaloonRepository, SaloonRepository>();
        services.AddTransient<ISeatRepository, SeatRepository>();
        //-----------|  Services
        services.AddTransient<IActiveMovieService, ActiveMovieService>();
        services.AddTransient<IMovieService, MovieService>();
        services.AddTransient<IBookingService, BookingService>();
        services.AddTransient<ITimeService, TimeService>();
        services.AddTransient<ISaloonService, SaloonService>();
        services.AddTransient<ISeatService, SeatService>();
    }
}
