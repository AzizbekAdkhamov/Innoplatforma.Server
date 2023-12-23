using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;
using Microsoft.AspNetCore.Http;
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
        var personalData = await _personalDataRepository
            .SelectAll()
            .Where(p => p.PassportNumber == dto.PassportNumber
                    && p.PassportSeria.ToLower() == dto.PassportSeria.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personalData is not null)
            throw new InnoplatformException(409, "Personal Data is already exist.");

        var passportFrontFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetFront).Result;
        var passportBackFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetsBack).Result;

        var mapped = _mapper.Map<PersonalData>(dto);
        mapped.PassportFrontPhotoPath = passportFrontFilePath;
        mapped.PassportBackPhotoPath = passportBackFilePath;
        DateTime convertPassportEndDate = new DateTime(dto.PassportEndDate.Year, dto.PassportEndDate.Month, dto.PassportEndDate.Day);
        mapped.PassportEndDate = convertPassportEndDate;
        DateTime convertBithDay = new DateTime(dto.BirthDate.Year, dto.BirthDate.Month, dto.BirthDate.Day);
        mapped.BirthDate = convertBithDay;


        var createdPersonalData = await _personalDataRepository.InsertAsync(mapped);

        return _mapper.Map<PersonalDataForResultDto>(createdPersonalData);
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
