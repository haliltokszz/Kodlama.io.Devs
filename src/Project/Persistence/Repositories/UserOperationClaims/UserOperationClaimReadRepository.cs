using Application.Services.Repositories.UserOperationClaims;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserOperationClaims;

public class UserOperationClaimReadRepository: ReadRepository<UserOperationClaim, KodlamaIODevsDbContext>, IUserOperationClaimReadRepository
{
    public UserOperationClaimReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}