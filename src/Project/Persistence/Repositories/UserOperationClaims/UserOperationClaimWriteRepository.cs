using Application.Services.Repositories.UserOperationClaims;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserOperationClaims;

public class UserOperationClaimWriteRepository: WriteRepository<UserOperationClaim, KodlamaIODevsDbContext>, IUserOperationClaimWriteRepository
{
    public UserOperationClaimWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}