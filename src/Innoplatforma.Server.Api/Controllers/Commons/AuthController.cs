using Innoplatforma.Server.Service.DTOs.Logins;
using Innoplatforma.Server.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Commons;

[EnableRateLimiting("fixed")]
public class AuthController : BaseController
{
    private readonly IAccountService accountService;

    public AuthController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpPost]
    [Route("login")]
    public async ValueTask<IActionResult> login([FromBody] LoginDto loginDto)
        => Ok(await accountService.LoginAsync(loginDto));
}