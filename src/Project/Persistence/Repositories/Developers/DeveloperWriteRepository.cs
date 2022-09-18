using Application.Services.Repositories.Developers;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Developers;

public class DeveloperWriteRepository: WriteRepository<Developer, KodlamaIODevsDbContext>, IDeveloperWriteRepository
{
    public DeveloperWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}