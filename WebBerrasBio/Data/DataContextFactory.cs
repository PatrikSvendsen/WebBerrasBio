using DataLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebBerrasBio.Data;

/// <summary>
/// Class som enbart hanterar kopplingen till db. Här hämtar vi säger vi varat filen appsettings finns och hämtar sedan
/// connectionStrings ur den.
/// </summary>
public class DataContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    /// <summary>
    /// Metod för att hämta och sätta connectionstring 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
        .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("WebBerrasBio"));
        return new RepositoryContext(builder.Options);
    }
}
