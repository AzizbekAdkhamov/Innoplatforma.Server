using AutoMapper;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Domain.Entities.Sections;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;
using Innoplatforma.Server.Service.DTOs.Auth.RolePermissions;
using Innoplatforma.Server.Service.DTOs.Organizations.Links;
using Innoplatforma.Server.Service.DTOs.Sections;

namespace Innoplatforma.Server.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Permissions

        CreateMap<Permission, PermissionForResultDto>().ReverseMap();
        CreateMap<Permission, PermissionForUpdateDto>().ReverseMap();
        CreateMap<Permission, PermissionForCreationDto>().ReverseMap();

        // Role

        CreateMap<Role, RoleForUpdateDto>().ReverseMap();
        CreateMap<Role, RoleForResultDto>().ReverseMap();
        CreateMap<Role, RoleForCreationDto>().ReverseMap();

        // RolePermession

        CreateMap<RolePermession, RolePermessionForResultDto>().ReverseMap();
        CreateMap<RolePermession, RolePermissionForUpdateDto>().ReverseMap();
        CreateMap<RolePermession, RolePermissionForCreationDto>().ReverseMap();

        // Sections
        CreateMap<Section, SectionForCreationDto>().ReverseMap();
        CreateMap<Section, SectionForResultDto>().ReverseMap();
        CreateMap<Section, SectionForUpdateDto>().ReverseMap();

        // Links
        CreateMap<Link, LinkForCreationDto>().ReverseMap();
        CreateMap<Link, LinkForUpdateDto>().ReverseMap();
        CreateMap<Link, LinkForResultDto>().ReverseMap();
    }
}