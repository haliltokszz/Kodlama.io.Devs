using Application.Services.Repositories.Developers;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Developers;

public class DeveloperReadRepository: ReadRepository<Developer, KodlamaIODevsDbContext>, IDeveloperReadRepository
{
    public DeveloperReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}