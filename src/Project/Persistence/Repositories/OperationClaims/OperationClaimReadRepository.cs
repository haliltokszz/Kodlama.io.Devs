using Application.Services.Repositories.OperationClaims;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.OperationClaims;

public class OperationClaimReadRepository: ReadRepository<OperationClaim, KodlamaIODevsDbContext>, IOperationClaimReadRepository
{
    public OperationClaimReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}