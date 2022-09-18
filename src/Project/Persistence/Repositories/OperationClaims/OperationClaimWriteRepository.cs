using Application.Services.Repositories.OperationClaims;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.OperationClaims;

public class OperationClaimWriteRepository: WriteRepository<OperationClaim, KodlamaIODevsDbContext>, IOperationClaimWriteRepository
{
    public OperationClaimWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}