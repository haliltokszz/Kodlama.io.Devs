using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProgrammingLanguageReadRepository: ReadRepository<ProgrammingLanguage, KodlamaIODevsDbContext>, IProgrammingLanguageReadRepository
{
    public ProgrammingLanguageReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}