using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Data.IRepositories.Sections;
using Innoplatforma.Server.Data.Repositories;
using Innoplatforma.Server.Data.Repositories.Auth;
using Innoplatforma.Server.Data.Repositories.Sections;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Service.Interfaces.Sections;
using Innoplatforma.Server.Service.Services.Auth;
using Innoplatforma.Server.Service.Services.Sections;

namespace Innoplatforma.Server.Api.Extentions;

public static class ServiceExtentions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Generic Repository
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        // Permissions
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IPermissionService, PermissionService>();

        //Sections
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<ISectionService, SectionService>();
    }
}
