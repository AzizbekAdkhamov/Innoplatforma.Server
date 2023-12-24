using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Commons.Helpers;
using Innoplatforma.Server.Service.Configurations;
using Innoplatforma.Server.Service.DTOs.Investments;
using Innoplatforma.Server.Service.Interfaces.Investments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Investments
{
    [EnableRateLimiting("fixed")]
    public class InvestmentsController : BaseController
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet("user-self"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetPersonalApplication()
            => Ok(await _investmentService.RetrieveByIdAsync(long.Parse(HttpContextHelper.UserId)));

        [Authorize(Roles = "Investor, Admin")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] InvestmentForCreateDto dto)
            => Ok(await _investmentService.AddAsync(dto));

        [Authorize(Roles = "Investor, Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _investmentService.RetrieveAllAsync(@params));

        [Authorize(Roles = "Investor, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
            => Ok(await _investmentService.RetrieveByIdAsync(id));

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] long id)
            => Ok(await _investmentService.RemoveAsync(id));

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] InvestmentForUpdateDto dto)
            => Ok(await _investmentService.ModifyAsync(id, dto));
    }
}
