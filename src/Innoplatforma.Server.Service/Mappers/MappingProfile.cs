using AutoMapper;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;

namespace Innoplatforma.Server.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Permissions
        CreateMap<Permission, PermissionForCreationDto>().ReverseMap();
        CreateMap<Permission, PermissionForResultDto>().ReverseMap();
        CreateMap<Permission, PermissionForUpdateDto>().ReverseMap();
    }
}