using Core.Persistence.Dynamic;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class KodlamaIODevsDbContext : DbContext
{
    public KodlamaIODevsDbContext(DbContextOptions<KodlamaIODevsDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Framework> Frameworks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddGlobalFilter(); //GlobalFilter for getting only active records
        base.OnModelCreating(modelBuilder);

        #region ProgrammingLanguage
        modelBuilder.Entity<ProgrammingLanguage>(a =>
        {
            a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
            a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            a.Property(p => p.isDeleted).HasColumnName("isDeleted");
            a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
            a.HasMany(p=>p.Frameworks);
        });
        ProgrammingLanguage[] programmingLanguagesSeeds =
        {
            new(Guid.Parse("52120BB7-82F4-4FB7-9796-83F330C5ABD7"), "C#"), 
            new(Guid.Parse("A827A9D1-8087-4E4D-BA7D-024903777CDA"), "JavaScript"), 
            new(Guid.Parse("AB2F1F1E-D05D-4DB0-BE45-E530836B12D2"), "TypeScript")
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeeds);
        #endregion

        #region Framework
        modelBuilder.Entity<Framework>(a =>
        {
            a.ToTable("Frameworks").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            a.Property(p => p.Name).HasColumnName("Name");
            a.Property(p => p.Version).HasColumnName("Version");
            a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            a.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            a.Property(p => p.isDeleted).HasColumnName("isDeleted");
            a.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
            a.HasOne(p => p.ProgrammingLanguage);
        });
        Framework[] frameworkSeeds =
        {
            new(Guid.NewGuid(),Guid.Parse("52120BB7-82F4-4FB7-9796-83F330C5ABD7"),  ".NET", "6.0.8"), 
            new(Guid.NewGuid(),Guid.Parse("A827A9D1-8087-4E4D-BA7D-024903777CDA"),  "React", "18.2.0"), 
            new(Guid.NewGuid(),Guid.Parse("AB2F1F1E-D05D-4DB0-BE45-E530836B12D2"),  "Next.js", "12.22.0"),
        };
        modelBuilder.Entity<Framework>().HasData(frameworkSeeds);
        #endregion

        #region User
        modelBuilder.Entity<User>(a =>
        {
            a.ToTable("Users").HasKey(k => k.Id);
            a.HasMany(p=>p.RefreshTokens);
            a.HasMany(p=>p.UserOperationClaims);
        });
        // User[] userSeeds =
        // {
        //     new(Guid.Parse("a2c9b2a3-269c-497e-ae25-9f25e42bf5a8"), "Halil", "Toksöz",  "toksozhalil@gmail.com"), 
        //     new(Guid.Parse("cbc0bf81-ba09-42c3-8d90-cf4a3bcd4e14"), "Ulaş", "Bağlı",  "ulasbagli@gmail.com"), 
        //     new(Guid.Parse("d8797db2-39f8-4bdc-981b-0042d1690ae1"), "Emre", "Koçan",  "emrekocan@gmail.com")
        // };
        // modelBuilder.Entity<User>().HasData(userSeeds);

        #endregion
        
        #region Developer
        modelBuilder.Entity<Developer>(a =>
        {
            a.ToTable("Developers").HasKey(k => k.Id);
            a.Property(d => d.Id).HasColumnName("Id");
            a.Property(d => d.UserId).HasColumnName("UserId");
            a.Property(d => d.CreatedDate).HasColumnName("CreatedDate");
            a.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
            a.Property(d => d.isDeleted).HasColumnName("isDeleted");
            a.Property(d => d.DeletedDate).HasColumnName("DeletedDate");
            a.HasOne(d=>d.User);
            a.HasMany(d=>d.SocialMedias);
        });
        // Developer[] developerSeeds =
        // {
        //     new(Guid.Parse("99409030-86b1-48ad-8bae-b09e42d9d622"),Guid.Parse("a2c9b2a3-269c-497e-ae25-9f25e42bf5a8")), 
        //     new(Guid.Parse("f578a7cc-905c-4741-9552-2dd4feeb4fbf"),Guid.Parse("cbc0bf81-ba09-42c3-8d90-cf4a3bcd4e14")),
        // };
        // modelBuilder.Entity<Developer>().HasData(developerSeeds);

        #endregion

        #region SocialMedia
        modelBuilder.Entity<SocialMedia>(a =>
        {
            a.ToTable("SocialMedias").HasKey(k => k.Id);
            a.Property(s => s.Id).HasColumnName("Id");
            a.Property(s => s.Name).HasColumnName("Name");
            a.Property(s => s.Url).HasColumnName("URL");
            a.Property(s => s.DeveloperId).HasColumnName("DeveloperId");
            a.Property(s => s.CreatedDate).HasColumnName("CreatedDate");
            a.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
            a.Property(s => s.isDeleted).HasColumnName("isDeleted");
            a.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
            a.HasOne(s=>s.Developer);
        });
        // SocialMedia[] socialMediaSeeds =
        // {
        //     new(Guid.Parse("bffadc3b-2e19-472c-9433-cb7f67f28afb"),Guid.Parse("99409030-86b1-48ad-8bae-b09e42d9d622"), "GitHub", "https://github.com/haliltokszz"), 
        //     new(Guid.Parse("e2e9bdd0-dd83-4282-9660-95b1b825b9c6"),Guid.Parse("f578a7cc-905c-4741-9552-2dd4feeb4fbf"), "Github", ""),
        // };
        // modelBuilder.Entity<SocialMedia>().HasData(socialMediaSeeds);

        #endregion
        
        #region OperationClaim
        modelBuilder.Entity<OperationClaim>(a =>
        {
            a.ToTable("OperationClaims").HasKey(k => k.Id);
            a.Property(o => o.Id).HasColumnName("Id");
            a.Property(o => o.Name).HasColumnName("Name");
            a.Property(o => o.CreatedDate).HasColumnName("CreatedDate");
            a.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
            a.Property(o => o.isDeleted).HasColumnName("isDeleted");
            a.Property(o => o.DeletedDate).HasColumnName("DeletedDate");
        });
        OperationClaim[] operationClaimSeeds =
        {
            new(Guid.Parse("a2c9b2a3-269c-497e-ae25-9f25e42bf5a8"), OperationClaimsEnum.Admin.ToString()), 
            new(Guid.Parse("cbc0bf81-ba09-42c3-8d90-cf4a3bcd4e14"), OperationClaimsEnum.User.ToString()), 
            new(Guid.Parse("d8797db2-39f8-4bdc-981b-0042d1690ae1"), OperationClaimsEnum.Developer.ToString())
        };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);
        #endregion
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