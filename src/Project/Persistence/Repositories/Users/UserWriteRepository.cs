using Application.Services.Repositories.Users;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class UserWriteRepository: WriteRepository<User, KodlamaIODevsDbContext>, IUserWriteRepository
{
    public UserWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}