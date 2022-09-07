using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

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
            services.AddScoped<IProgrammingLanguageWriteRepository, ProgrammingLanguageWriteRepository>();
            services.AddScoped<IProgrammingLanguageReadRepository, ProgrammingLanguageReadRepository>();

            return services;
        }
    }
}
