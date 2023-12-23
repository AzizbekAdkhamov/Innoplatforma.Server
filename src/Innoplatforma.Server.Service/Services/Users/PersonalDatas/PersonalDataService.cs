using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Service.Services.Users.PersonalDatas;

public class PersonalDataService : IPersonalDataService
{
    private readonly IMapper _mapper;
    private readonly IPersonalDataRepository _personalDataRepository;

    public PersonalDataService(
        IMapper mapper,
        IPersonalDataRepository personalDataRepository
        )
    {
        _mapper = mapper;
        _personalDataRepository = personalDataRepository;
    }

    public async Task<PersonalDataForResultDto> CreateAsync(PersonalDataForCreationDto dto)
    {
        throw new NotImplementedException();
        //var personalData = await _personalDataRepository
        //    .SelectAll()
        //    .Where(p => p.PassportNumber == dto.PassportNumber
        //            && p.PassportSeria.ToLower() == dto.PassportSeria.ToLower())
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync();

        //if (personalData is not null)
        //    throw new InnoplatformException(409, "Personal Data is already exist.");



        //var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.PassportAssetFrontId.FileName);
        //var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "PersonalData", fileName);
        //using (var stream = new FileStream(rootPath, FileMode.Create))
        //{
        //    await dto.PassportAssetFrontId.CopyToAsync(stream);
        //    await stream.FlushAsync();
        //    stream.Close();
        //}
        //var mappedAsset = new PersonalDataAssets()
        //{
        //    Name = fileName,
        //    Extension = dto.PassportAssetFrontId.ContentType,
        //    Type = dto.PassportAssetFrontId.ContentType.ToString(),
        //    Path = rootPath,
        //    Size = dto.PassportAssetFrontId.Length
        //};

        //var PassportAssetFrontResult = _personalDataAssetsRepository.InsertAsync(mappedAsset);

        //var mapped = _mapper.Map<PersonalData>(dto);

        //var createdPersonalData = await _personalDataRepository.InsertAsync(mapped);








        //return _mapper.Map<PersonalDataForResultDto>(createdPersonalData);
    }

    public Task<PersonalDataForResultDto> ModifyAsync(long id, PersonalDataForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PersonalDataForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
