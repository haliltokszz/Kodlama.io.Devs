using System.Reflection;
using Application.Features.Authentication.Rules;
using Application.Features.Developers.Rules;
using Application.Features.Frameworks.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.SocialMedias.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<FrameworkBusinessRules>();
        services.AddScoped<DeveloperBusinessRules>();
        services.AddScoped<AuthenticationBusinessRules>();
        services.AddScoped<SocialMediaBusinessRules>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        
        services.AddTransient<ITokenHelper, JwtHelper>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;

    }
}