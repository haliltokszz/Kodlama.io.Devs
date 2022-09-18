using Application.Services.Repositories.RefreshTokens;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.RefreshTokens;

public class RefreshTokenWriteRepository: WriteRepository<RefreshToken, KodlamaIODevsDbContext>, IRefreshTokenWriteRepository
{
    public RefreshTokenWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}