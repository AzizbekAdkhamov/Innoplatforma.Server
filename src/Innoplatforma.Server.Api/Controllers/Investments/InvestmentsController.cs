using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Investments;
using Innoplatforma.Server.Service.DTOs.References.Locations;
using Innoplatforma.Server.Service.Interfaces.Investments;
using Innoplatforma.Server.Service.Interfaces.References;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Investments
{
    public class InvestmentsController : BaseController
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] InvestmentForCreateDto dto)
            => Ok(await _investmentService.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _investmentService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _investmentService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _investmentService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] InvestmentForUpdateDto dto)
            => Ok(await _investmentService.ModifyAsync(id, dto));
    }
}
