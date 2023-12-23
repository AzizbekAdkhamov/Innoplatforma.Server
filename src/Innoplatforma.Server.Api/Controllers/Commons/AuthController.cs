using Innoplatforma.Server.Service.DTOs.Logins;
using Innoplatforma.Server.Service.Interfaces.Accounts;
using Innoplatforma.Server.Service.Interfaces.Commons;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Commons;

public class AuthController : BaseController
{
    private readonly IAccountService accountService;

    public AuthController(IAccountService accountService, IAuthService authService)
    {
        this.accountService = accountService;
    }

    [HttpPost]
    [Route("login")]
    public async ValueTask<IActionResult> login([FromBody] LoginDto loginDto)
        => Ok(await accountService.LoginAsync(loginDto));
}