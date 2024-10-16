using GoSolution.Application.Common.Interfaces.Authentication;
using GoSolution.Application.Common.Interfaces.Persistence;
using GoSolution.Application.Common.Interfaces.Services;
using GoSolution.Application.Services.Authentication;
using GoSolution.Infrastructure.Authentication;
using GoSolution.Infrastructure.Persistence;
using GoSolution.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoSolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }
}