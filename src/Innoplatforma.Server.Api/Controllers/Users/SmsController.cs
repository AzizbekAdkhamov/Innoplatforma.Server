using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Interfaces.Users;
using Innoplatforma.Server.Service.Services.Accounts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Users;

[Authorize(Roles = "Admin")]
public class SmsController : BaseController
{
    private readonly ISmsService _smsService;

    public SmsController(ISmsService smsService)
    {
        _smsService = smsService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageAsync(Message message)
        => Ok(await _smsService.SendAsync(message));
}