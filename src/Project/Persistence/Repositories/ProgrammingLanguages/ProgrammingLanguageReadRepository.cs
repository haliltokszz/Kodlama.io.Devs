using Application.Services.Repositories.ProgrammingLanguages;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ProgrammingLanguages;

public class ProgrammingLanguageReadRepository: ReadRepository<ProgrammingLanguage, KodlamaIODevsDbContext>, IProgrammingLanguageReadRepository
{
    public ProgrammingLanguageReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}