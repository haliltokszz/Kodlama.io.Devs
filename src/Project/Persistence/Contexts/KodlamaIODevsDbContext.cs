using Core.Persistence.Dynamic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class KodlamaIODevsDbContext : DbContext
{
    public KodlamaIODevsDbContext(DbContextOptions<KodlamaIODevsDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddGlobalFilter(); //GlobalFilter for getting only active records
        base.OnModelCreating(modelBuilder);
        
        ProgrammingLanguage[] programmingLanguagesSeeds = { new(Guid.NewGuid(), "C#"), new(Guid.NewGuid(), "JavaScript"), new(Guid.NewGuid(), "TypeScript") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeeds);
    }
}