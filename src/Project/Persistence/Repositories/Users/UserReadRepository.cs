using Application.Services.Repositories.Users;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class UserReadRepository: ReadRepository<User, KodlamaIODevsDbContext>, IUserReadRepository
{
    public UserReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}