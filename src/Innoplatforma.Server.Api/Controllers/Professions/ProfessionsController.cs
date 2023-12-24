﻿using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.Dtos.Auth.Roles;
using Innoplatforma.Server.Service.DTOs.Professions;
using Innoplatforma.Server.Service.Interfaces.Auth;
using Innoplatforma.Server.Service.Interfaces.Professions;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Professions
{
    public class ProfessionsController : BaseController
    {
        private readonly IProfessionService _professionService;

        public ProfessionsController(IProfessionService userProfessionService)
        {
            _professionService = userProfessionService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] ProfessionForCreatedDto dto)
            => Ok(await _professionService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _professionService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await _professionService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
            => Ok(await _professionService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProfessionForUpdateDto dto)
            => Ok(await _professionService.ModifyAsync(id, dto));
    }
}
