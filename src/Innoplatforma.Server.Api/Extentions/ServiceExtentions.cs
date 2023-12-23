﻿using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Data.IRepositories.Organizations;
using Innoplatforma.Server.Data.IRepositories.Organizations.Links;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Data.IRepositories.References;
using Innoplatforma.Server.Data.IRepositories.Sections;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Data.Repositories;
using Innoplatforma.Server.Data.Repositories.Auth;
using Innoplatforma.Server.Data.Repositories.Organizations;
using Innoplatforma.Server.Data.Repositories.Organizations.Links;
using Innoplatforma.Server.Data.Repositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Data.Repositories.References;
using Innoplatforma.Server.Data.Repositories.Sections;
using Innoplatforma.Server.Data.Repositories.Users;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Service.Interfaces.Organizations.Links;
using Innoplatforma.Server.Service.Interfaces.Organizations.Organization;
using Innoplatforma.Server.Service.Interfaces.References;
using Innoplatforma.Server.Service.Interfaces.Sections;
using Innoplatforma.Server.Service.Interfaces.Users;
using Innoplatforma.Server.Service.Services.Auth;
using Innoplatforma.Server.Service.Services.Organizations;
using Innoplatforma.Server.Service.Services.Organizations.Links;
using Innoplatforma.Server.Service.Services.References;
using Innoplatforma.Server.Service.Services.Sections;
using Innoplatforma.Server.Service.Services.Users;

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

        // Organizations
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        
        // Link Details
        services.AddScoped<IOrganizationDetailRepository, OrganizationDetailRepository>();

        // Links
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<ILinkRepository, LinkRepository>();

        // Locations
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IlocationService, LocationService>();

        // Users
        services.AddScoped<IUsersService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
