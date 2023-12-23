using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Interfaces.Users;
using Innoplatforma.Server.Service.Services.Accounts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Innoplatforma.Server.Api.Controllers.Users;

public class SmsController : BaseController
{
    private readonly ISmsService smsService;

    public SmsController(ISmsService smsService)
    {
        this.smsService = smsService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageAsync(Message message)
        => Ok(await this.smsService.SendAsync(message));


    [HttpPost("send-message-by-telegram/groupId/url/text")]
    public async Task<IActionResult> PostAsync(long groupId, string url, string text)
    {
        // Decode the URL parameter
        url = Uri.UnescapeDataString(url);

        return Ok(await smsService.SendMessageByTelegramAsync(groupId, url, text));
    }
}