using AutoMapper;
using Innoplatforma.Server.Data.IRepositories.References;
using Innoplatforma.Server.Domain.Entities.References;
using Innoplatforma.Server.Service.Commons.Extentions;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.References.Locations;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Interfaces.References;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Service.Services.References;

public class LocationService : IlocationService
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository roleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _locationRepository = roleRepository;
    }

    public async Task<LocationForResultDto> CreateAsync(LocationForCreation dto)
    {
        var location = await _locationRepository
            .SelectAll()
            .Where(l =>l.Latitude == dto.Latitude && l.Longitude == l.Longitude)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (location is not null)
            throw new InnoplatformException(409, "Location is already exist!");

        var mapLocation = _mapper.Map<Location>(dto);
        mapLocation.CreatedAt = DateTime.UtcNow;

        var createdLocation = await _locationRepository.InsertAsync(mapLocation);

        return _mapper.Map<LocationForResultDto>(createdLocation);
    }

    public async Task<LocationForResultDto> ModifyAsync(long id, LocationForUpdateDto dto)
    {
        var location = await _locationRepository.SelectByIdAsync(id);

        if (location is null)
            throw new InnoplatformException(404, "Location is not found");

        var mappedLocation = _mapper.Map(dto, location);
        mappedLocation.UpdatedAt = DateTime.UtcNow;

        await _locationRepository.UpdateAsync(mappedLocation);

        return _mapper.Map<LocationForResultDto>(mappedLocation);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var location = await _locationRepository.SelectByIdAsync(id);

        if (location is null)
            throw new InnoplatformException(404, "Location is not found");

        return await _locationRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var location = await _locationRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList<Location, long>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LocationForResultDto>>(location);
    }

    public async Task<LocationForResultDto> RetrieveByIdAsync(long id)
    {
        var location = await _locationRepository.SelectByIdAsync(id);

        if (location is null)
            throw new InnoplatformException(404, "Location is not found");

        return _mapper.Map<LocationForResultDto>(location);
    }
}
