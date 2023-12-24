using AutoMapper;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Domain.Entities.Sections;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.DTOs.Auth.Permissions;
using Innoplatforma.Server.Service.DTOs.Auth.RolePermissions;
using Innoplatforma.Server.Service.DTOs.Organizations.Links;
using Innoplatforma.Server.Domain.Entities.References;
using Innoplatforma.Server.Service.DTOs.References.Locations;
using Innoplatforma.Server.Service.DTOs.Sections;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDtos;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.DTOs.Professions;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;

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

        //Location
        CreateMap<Location, LocationForCreation>().ReverseMap();
        CreateMap<Location, LocationForResultDto>().ReverseMap();
        CreateMap<Location, LocationForUpdateDto>().ReverseMap();
        
        // Sections
        CreateMap<Section, SectionForCreationDto>().ReverseMap();
        CreateMap<Section, SectionForResultDto>().ReverseMap();
        CreateMap<Section, SectionForUpdateDto>().ReverseMap();

        // Links
        CreateMap<Link, LinkForCreationDto>().ReverseMap();
        CreateMap<Link, LinkForUpdateDto>().ReverseMap();
        CreateMap<Link, LinkForResultDto>().ReverseMap();
        
        // User
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        // Organization
        CreateMap<Organization, OrganizationForResultDto>().ReverseMap();
        CreateMap<Organization, OrganizationForUpdateDto>().ReverseMap();
        CreateMap<Organization, OrganizationForCreationDto>().ReverseMap();

        // Profession
        CreateMap<Profession, ProfessionForResultDto>().ReverseMap();
        CreateMap<Profession, ProfessionForUpdateDto>().ReverseMap();
        CreateMap<Profession, ProfessionForCreatedDto>().ReverseMap();

        // UserProfession
        CreateMap<UserProfession, UserProfessionForResultDto>().ReverseMap();
        CreateMap<UserProfession, UserProfessionForUpdateDto>().ReverseMap();
        CreateMap<UserProfession, UserProfessionForCreationDto>().ReverseMap();

        // PersonalDataForResultDto
        CreateMap<PersonalData, PersonalDataForResultDto>().ReverseMap();
        CreateMap<PersonalData, PersonalDataForUpdateDto> ().ReverseMap();
        CreateMap<PersonalData, PersonalDataForCreationDto> ().ReverseMap();
        CreateMap<PersonalDataForCreationDto, PersonalDataForResultDto> ().ReverseMap();


        //  Organization Details
        CreateMap<OrganizationDetail, OrganizationDetailForCreationDto>().ReverseMap();
        CreateMap<OrganizationDetail, OrganizationDetailForResultDto>().ReverseMap();
        CreateMap<OrganizationDetail, OrganizationDetailForUpdateDto>().ReverseMap();
        CreateMap<OrganizationDetailForCreationDto, OrganizationDetail>();

    }
}