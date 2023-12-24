using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Applications;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetails;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Service.Interfaces.Organizations.OrganizationDetails;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Service.Services.Organizations.OrganizationDetailServices;

public class OrganizationDetailService : IOrganizationDetailService
{
    private readonly IOrganizationDetailRepository _organizationDetailRepository;
    private readonly IMapper _mapper;

    public OrganizationDetailService(IOrganizationDetailRepository organizationDetailRepository,
                    IMapper mappper)
    {
        _organizationDetailRepository = organizationDetailRepository;
        _mapper = mappper;
    }

    public async Task<OrganizationDetailForResultDto> CreateAsync(OrganizationDetailForCreationDto dto)
    {
        
        var organizationDetail = await _organizationDetailRepository.SelectAll()
                .Where(org => org.Phone.ToLower() == dto.Phone.ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (organizationDetail is not null)
            throw new InnoplatformException(409, "Organization Detail is alredy exists!");

        var mapped = _mapper.Map<OrganizationDetail>(dto);

        mapped.FilePath = FileUploadHelper.UploadFile("OrganizationDetails", dto.Asset).Result;
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _organizationDetailRepository.InsertAsync(mapped);

        return _mapper.Map<OrganizationDetailForResultDto>(result);
    }

    public async Task<OrganizationDetailForResultDto> ModifyAsync(long id, OrganizationDetailForUpdateDto dto)
    {
        var organizationDetail = await _organizationDetailRepository.SelectAll()
                .Where(s => s.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (organizationDetail is null)
            throw new InnoplatformException(404, "OrganizationDetail is not found");

        var mappedOrganization = _mapper.Map(dto, organizationDetail);
        mappedOrganization.UpdatedAt = DateTime.UtcNow;

        await _organizationDetailRepository.UpdateAsync(mappedOrganization);

        return _mapper.Map<OrganizationDetailForResultDto>(mappedOrganization);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var organizationDetail = await _organizationDetailRepository.SelectAll()
                .Where(l => l.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (organizationDetail is null)
            throw new InnoplatformException(404, "Organization Detail is not found");

        return await _organizationDetailRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<OrganizationDetailForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var organizationDetails = await _organizationDetailRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<OrganizationDetail, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<OrganizationDetailForResultDto>>(organizationDetails);
    }

    public async Task<OrganizationDetailForResultDto> RetrieveByIdAsync(long id)
    {
        var organizationDetail = await _organizationDetailRepository.SelectByIdAsync(id);

        if (organizationDetail is null)
            throw new InnoplatformException(404, "OrganizationDetail is not found");

        return _mapper.Map<OrganizationDetailForResultDto>(organizationDetail);
    }

    //public async Task<OrganizationDetailForResultDto> UpdateAssetAsync(long orgId, long assetId, OrganizationDetailForCreationDto dto)
    //{
    //    var organizationDetail = await _organizationDetailRepository.SelectAll()
    //        .Where(org => org.Id == orgId)
    //        .FirstOrDefaultAsync();

    //    if (organizationDetail is null)
    //        throw new InnoplatformException(404, "OrganizationDetail is not found");

    //    // Delete the existing logo file if needed
    //    if (organizationDetail.AssetId is not 0)
    //    {
    //        var existingLogoPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, organizationDetail.Logo);
    //        if (File.Exists(existingLogoPath))
    //        {
    //            File.Delete(existingLogoPath);
    //        }
    //    }

    //    var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.formFile.FileName);
    //    var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Community", "Logos", fileName);

    //    using (var stream = new FileStream(rootPath, FileMode.Create))
    //    {
    //        await dto.formFile.CopyToAsync(stream);
    //        await stream.FlushAsync();
    //        stream.Close();
    //    }

    //    string resultImage = Path.Combine("Media", "Community", "Logos", fileName);

    //    organizationDetail.Logo = resultImage;
    //    var mappedCommunity = _mapper.Map<Community>(organizationDetail);
    //    var result = await _communityRepository.UpdateAsync(mappedCommunity);

    //    return _mapper.Map<CommunityForResultDto>(result);
    //}
}
