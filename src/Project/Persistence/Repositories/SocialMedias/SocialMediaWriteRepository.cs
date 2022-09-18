using Application.Services.Repositories.SocialMedias;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.SocialMedias;

public class SocialMediaWriteRepository : WriteRepository<SocialMedia, KodlamaIODevsDbContext>, ISocialMediaWriteRepository
{
    public SocialMediaWriteRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}