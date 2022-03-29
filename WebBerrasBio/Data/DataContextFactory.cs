using DataLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebBerrasBio.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
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
