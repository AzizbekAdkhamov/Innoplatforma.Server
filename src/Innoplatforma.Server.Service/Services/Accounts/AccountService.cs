using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Commons.Helpers;
using Innoplatforma.Server.Service.DTOs.Logins;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.Interfaces.Accounts;
using Innoplatforma.Server.Service.Interfaces.Commons;
using Microsoft.EntityFrameworkCore;


namespace Innoplatforma.Server.Service.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAuthService authService;
    private readonly IRepository<User, long> userRepository;
    public AccountService(
        IAuthService authService,
        IRepository<User, long> userRepository)
    {
        this.authService = authService;
        this.userRepository = userRepository;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
        /*var user = await userRepository.SelectAll()
                .Where(a => a.Phone == loginDto.PhoneNumber)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        if (user is null)
            throw new InnoplatformException(404, "Telefor raqam yoki parol xato kiritildi!");

        var hasherResult = PasswordHelper.Verify(loginDto.Password, user.Salt, user.Password);*/
    }
}
