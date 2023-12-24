﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Innoplatforma.Server.Api.Controllers.Commons;
using Innoplatforma.Server.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace Innoplatforma.Server.Api.Controllers.Accounts;

public class SendCodeByEmailsController : BaseController
{
    private readonly IEmailService emailService;

    public SendCodeByEmailsController(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("send-code")]
    public async Task<IActionResult> SendCodeByEmailAsync([EmailAddress, Required] string email)
        => Ok(await this.emailService.SendCodeByEmailAsync(email));

    [EnableRateLimiting("fixed")]
    [HttpPost("verify-code")]
    public IActionResult VerifyCode([EmailAddress, Required] string email, [Required] string code)
        => Ok(this.emailService.VerifyCode(email, code));
}
