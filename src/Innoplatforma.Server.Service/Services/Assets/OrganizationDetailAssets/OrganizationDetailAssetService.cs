using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Assets.OrganizationDetailAssets;
using Innoplatforma.Server.Domain.Entities.Assets;
using Innoplatforma.Server.Service.DTOs.Organizations.OrganizationDetailAssets;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Service.Interfaces.Assets.OrganizationDetailAssets;
using Microsoft.EntityFrameworkCore;


namespace Innoplatforma.Server.Service.Services.Assets.OrganizationDetailAssets;

public class OrganizationDetailAssetService : IOrganizationDetailAssetService
{
    private readonly IMapper _mapper;
    private readonly IOrganizationDetailAssetRepository _organizationDetailAssetRepository;

    public OrganizationDetailAssetService(IOrganizationDetailAssetRepository organizationDetailRepository, IMapper mapper)
    {
        _organizationDetailAssetRepository = organizationDetailRepository;
        _mapper = mapper;
    }
    public async Task<OrganizationDetailAssetForResultDto> AddAsync(OrganizationDetailAssetForCreationDto dto)
    {
        string value = WebHostEnviromentHelper.WebRootPath;
        var wwwRootPath = Path.Combine(value, "Media", "OrganizationDetailAssets");
        var assetsFolderPath = Path.Combine(wwwRootPath, "Media");
        var ImagesFolderPath = Path.Combine(assetsFolderPath, "OrganizationDetailAssets");
        
        if (!Directory.Exists(assetsFolderPath))
        {
            Directory.CreateDirectory(assetsFolderPath);
        }
        if (!Directory.Exists(ImagesFolderPath))
        {
            Directory.CreateDirectory(ImagesFolderPath);
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.FormFile.FileName);

        var fullPath = Path.Combine(wwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.FormFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string resultImage = Path.Combine("Media", "OrganizationDetailAsset", fileName);

        var mapped = _mapper.Map<OrganizationDetailAsset>(dto);
        mapped.Path = resultImage;
        mapped.Name = fileName;
        mapped.Extension = Path.GetExtension(fileName);
        mapped.Type = dto.FormFile.ContentType;
        mapped.CreatedAt = DateTime.UtcNow;

        var result = await _organizationDetailAssetRepository.InsertAsync(mapped);

        return _mapper.Map<OrganizationDetailAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var organizationDetailAsset = await _organizationDetailAssetRepository.SelectByIdAsync(id);

        if (organizationDetailAsset is null)
            throw new InnoplatformException(404, "OrganizationDetailAsset Asset is not found");

        var fullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, organizationDetailAsset.Path);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        return await _organizationDetailAssetRepository.DeleteAsync(id);
    }

    public async Task<OrganizationDetailAssetForResultDto> RetrieveByIdAsync(long id)
    {
        var organizationDetailAsset = await _organizationDetailAssetRepository.SelectByIdAsync(id);

        if (organizationDetailAsset is null)
            throw new InnoplatformException(404, "OrganizationDetailAsset is not found");

        return _mapper.Map<OrganizationDetailAssetForResultDto>(organizationDetailAsset);
    }
}
