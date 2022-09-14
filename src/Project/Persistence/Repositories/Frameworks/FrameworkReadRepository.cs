using Application.Services.Repositories.Frameworks;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Frameworks;

public class FrameworkReadRepository: ReadRepository<Framework, KodlamaIODevsDbContext>, IFrameworkReadRepository
{
    public FrameworkReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}