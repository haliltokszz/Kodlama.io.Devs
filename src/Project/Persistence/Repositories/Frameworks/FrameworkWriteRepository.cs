using Application.Services.Repositories.Frameworks;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Frameworks;

public class FrameworkWriteRepository: WriteRepository<Framework, KodlamaIODevsDbContext>, IFrameworkWriteRepository
{
    public FrameworkWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}