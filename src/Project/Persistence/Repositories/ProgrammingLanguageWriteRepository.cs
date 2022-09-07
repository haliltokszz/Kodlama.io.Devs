using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProgrammingLanguageWriteRepository : WriteRepository<ProgrammingLanguage, KodlamaIODevsDbContext>, IProgrammingLanguageWriteRepository
{
    public ProgrammingLanguageWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}