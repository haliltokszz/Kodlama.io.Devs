using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;

namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KodlamaIODevsDbContext>
{
    public KodlamaIODevsDbContext CreateDbContext(string[] args)
    {
        ConfigurationManager configManager = new ConfigurationManager();
        configManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
        configManager.AddJsonFile("appsettings.json");
        
        var optionsBuilder = new DbContextOptionsBuilder<KodlamaIODevsDbContext>();
        optionsBuilder.UseSqlServer(configManager.GetConnectionString("KodlamaIODevsConnectionString"));

        return new(optionsBuilder.Options);
    }
}