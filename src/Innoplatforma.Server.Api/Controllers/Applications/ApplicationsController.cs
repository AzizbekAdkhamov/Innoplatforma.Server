using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Applications;
using Innoplatforma.Server.Service.Interfaces.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Applications
{

    [EnableRateLimiting("fixed")]
    public class ApplicationsController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] ApplicationForCreationDto dto)
            => Ok(await _applicationService.CreateAsync(dto));

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _applicationService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _applicationService.RetrieveByIdAsync(id));

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _applicationService.RemoveAsync(id));

        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] ApplicationForUpdateDto dto)
            => Ok(await _applicationService.ModifyAsync(id, dto));
    }
}
