using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Organizations.Links;
using Innoplatforma.Server.Service.DTOs.References.Locations;
using Innoplatforma.Server.Service.Interfaces.Organizations.Links;
using Innoplatforma.Server.Service.Interfaces.References;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Locations
{
    public class LocationsController : BaseController
    {
        private readonly IlocationService _locationService;

        public LocationsController(IlocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] LocationForCreation dto)
            => Ok(await _locationService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _locationService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _locationService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _locationService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] LocationForUpdateDto dto)
            => Ok(await _locationService.ModifyAsync(id, dto));
    }
}
