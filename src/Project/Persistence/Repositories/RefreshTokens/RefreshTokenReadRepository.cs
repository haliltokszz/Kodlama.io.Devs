using Application.Services.Repositories.RefreshTokens;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.RefreshTokens;

public class RefreshTokenReadRepository: ReadRepository<RefreshToken, KodlamaIODevsDbContext>, IRefreshTokenReadRepository
{
    public RefreshTokenReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}