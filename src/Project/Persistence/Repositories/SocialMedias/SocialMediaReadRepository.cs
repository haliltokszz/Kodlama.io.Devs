using Application.Services.Repositories.SocialMedias;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.SocialMedias;

public class SocialMediaReadRepository: ReadRepository<SocialMedia, KodlamaIODevsDbContext>, ISocialMediaReadRepository
{
    public SocialMediaReadRepository(KodlamaIODevsDbContext context) : base(context)
    {
    }
}