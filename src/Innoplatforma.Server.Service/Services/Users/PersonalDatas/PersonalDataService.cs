using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Service.Helpers;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Service.DTOs.Users.PersonalDatas;
using Innoplatforma.Server.Service.Interfaces.Users.PersonalDatas;
using Innoplatforma.Server.Service.DTOs.Users.UserProffesions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Data.Repositories.Users;
using Innoplatforma.Server.Service.DTOs.Users;
using Innoplatforma.Server.Service.Commons.Extentions;

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
            .Where(p => p.PassportNumber == dto.PassportNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (personalData is not null)
            throw new InnoplatformException(409, "Personal Data is already exist.");

        var passportFrontFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetFront).Result;
        var passportBackFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetsBack).Result;

        var mapped = _mapper.Map<PersonalData>(dto);
        mapped.PassportFrontPhotoPath = passportFrontFilePath;
        mapped.PassportBackPhotoPath = passportBackFilePath;

        DateTime convertPassportEndDate = new DateTime(dto.PassportEndDate.Year, dto.PassportEndDate.Month, dto.PassportEndDate.Day, 0, 0, 0, DateTimeKind.Utc);
        DateTime convertBithDay = new DateTime(dto.BirthDate.Year, dto.BirthDate.Month, dto.BirthDate.Day, 0, 0, 0, DateTimeKind.Utc);
        
        mapped.PassportEndDate = convertPassportEndDate;
        mapped.BirthDate = convertBithDay;


        var createdPersonalData = await _personalDataRepository.InsertAsync(mapped);

        return _mapper.Map<PersonalDataForResultDto>(createdPersonalData);
    }

    public async Task<PersonalDataForResultDto> ModifyAsync(long id, PersonalDataForUpdateDto dto)
    {
        var existingPersonalData = await _personalDataRepository.SelectByIdAsync(id);

        if (existingPersonalData == null)
            throw new InnoplatformException(404, "Personal Data not found.");

        _mapper.Map(dto, existingPersonalData);

        if (dto.PassportAssetFront != null)
        {
            var newPassportFrontFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetFront).Result;
            existingPersonalData.PassportFrontPhotoPath = newPassportFrontFilePath;
        }

        if (dto.PassportAssetsBack != null)
        {
            var newPassportBackFilePath = FileUploadHelper.UploadFile("PersonalData", dto.PassportAssetsBack).Result;
            existingPersonalData.PassportBackPhotoPath = newPassportBackFilePath;
        }
        if (dto.PassportEndDate.HasValue)
            existingPersonalData.PassportEndDate = new DateTime(dto.PassportEndDate.Value.Year, dto.PassportEndDate.Value.Month, dto.PassportEndDate.Value.Day, 0, 0, 0, DateTimeKind.Utc);
        
        if (dto.BirthDate.HasValue)
            existingPersonalData.BirthDate = new DateTime(dto.BirthDate.Value.Year, dto.BirthDate.Value.Month, dto.BirthDate.Value.Day, 0, 0, 0, DateTimeKind.Utc);

        await _personalDataRepository.UpdateAsync(existingPersonalData);

        var updatedPersonalDataDto = _mapper.Map<PersonalDataForResultDto>(existingPersonalData);

        return updatedPersonalDataDto;
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var existingPersonalData = await _personalDataRepository.SelectByIdAsync(id);

        if (existingPersonalData == null)
            throw new InnoplatformException(404, "Personal Data not found.");

        await _personalDataRepository.DeleteAsync(existingPersonalData.Id);

        return true;
    }

    public async Task<IEnumerable<PersonalDataForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var personalData = await _personalDataRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<PersonalData, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<PersonalDataForResultDto>>(personalData);
    }

    public async Task<PersonalDataForResultDto> RetrieveByIdAsync(long id)
    {
        var personalData = await _personalDataRepository.SelectByIdAsync(id);

        if (personalData == null)
            throw new InnoplatformException(404, "Personal Data not found.");

        var personalDataDto = _mapper.Map<PersonalDataForResultDto>(personalData);

        return personalDataDto;
    }

}
