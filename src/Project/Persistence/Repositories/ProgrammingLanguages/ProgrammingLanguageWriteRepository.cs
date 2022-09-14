using Application.Services.Repositories.ProgrammingLanguages;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ProgrammingLanguages;

public class ProgrammingLanguageWriteRepository : WriteRepository<ProgrammingLanguage, KodlamaIODevsDbContext>, IProgrammingLanguageWriteRepository
{
    public ProgrammingLanguageWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}