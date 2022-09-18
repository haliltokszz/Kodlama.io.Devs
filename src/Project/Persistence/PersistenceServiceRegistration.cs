using Application.Services.Repositories.Developers;
using Application.Services.Repositories.Frameworks;
using Application.Services.Repositories.OperationClaims;
using Application.Services.Repositories.ProgrammingLanguages;
using Application.Services.Repositories.RefreshTokens;
using Application.Services.Repositories.SocialMedias;
using Application.Services.Repositories.UserOperationClaims;
using Application.Services.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Developers;
using Persistence.Repositories.Frameworks;
using Persistence.Repositories.OperationClaims;
using Persistence.Repositories.ProgrammingLanguages;
using Persistence.Repositories.RefreshTokens;
using Persistence.Repositories.SocialMedias;
using Persistence.Repositories.UserOperationClaims;
using Persistence.Repositories.Users;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<KodlamaIODevsDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaIODevsConnectionString")));

            #region ProgrammingLanguages Repositories
            services.AddScoped<IProgrammingLanguageWriteRepository, ProgrammingLanguageWriteRepository>();
            services.AddScoped<IProgrammingLanguageReadRepository, ProgrammingLanguageReadRepository>();
            #endregion
            
            #region Frameworks Repositories
            services.AddScoped<IFrameworkWriteRepository, FrameworkWriteRepository>();
            services.AddScoped<IFrameworkReadRepository, FrameworkReadRepository>();
            #endregion
            
            #region Users Repositories
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            #endregion
            
            #region RefreshTokens Repositories
            services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
            services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();
            #endregion
            
            #region OperationClaims Repositories
            services.AddScoped<IOperationClaimReadRepository, OperationClaimReadRepository>();
            services.AddScoped<IOperationClaimWriteRepository, OperationClaimWriteRepository>();
            #endregion
            
            #region UserOperationClaims Repositories
            services.AddScoped<IUserOperationClaimWriteRepository, UserOperationClaimWriteRepository>();
            services.AddScoped<IUserOperationClaimReadRepository, UserOperationClaimReadRepository>();
            #endregion
            
            #region SocialMedias Repositories
            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();
            #endregion
            
            #region Developers Repositories
            services.AddScoped<IDeveloperWriteRepository, DeveloperWriteRepository>();
            services.AddScoped<IDeveloperReadRepository, DeveloperReadRepository>();
            #endregion

            return services;
        }
    }
}
