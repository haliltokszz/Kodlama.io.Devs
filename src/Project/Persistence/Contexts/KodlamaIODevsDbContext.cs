using Core.Persistence.Dynamic;
using Core.Persistence.Repositories;
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entities = ChangeTracker.Entries<Entity>();
        foreach (var entity in entities)
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => entity.Entity.UpdatedDate = DateTime.Now,
                EntityState.Deleted => entity.Entity.DeletedDate = DateTime.Now,
                _ => DateTime.Now
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}