using Edufy.Application.Services;
using Edufy.Domain.Services;
using Edufy.Repository.UnitOfWorks;
using Edufy.SqlServer.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Edufy.Application.Extensions;

public static class ServiceRegistration
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IAuthService, AuthService>();
    }
}