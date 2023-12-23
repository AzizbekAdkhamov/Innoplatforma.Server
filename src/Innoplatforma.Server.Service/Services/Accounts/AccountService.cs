using Microsoft.EntityFrameworkCore;
using Innoplatforma.Server.Data.IRepositories;
using Innoplatforma.Server.Service.Exceptions;
using Innoplatforma.Server.Service.DTOs.Logins;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Service.Commons.Helpers;
using Innoplatforma.Server.Service.Interfaces.Accounts;
using Innoplatforma.Server.Service.Services.Commons;
using Innoplatforma.Server.Service.Interfaces.Commons;


namespace Innoplatforma.Server.Service.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IAuthService _authService;
    private readonly IRepository<User, long> _userRepository;
    public AccountService(
        IAuthService authService,
        IRepository<User, long> userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.SelectAll()
                .Where(a => a.Phone == loginDto.PhoneNumber)
                .Include(a => a.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (user is null)
            throw new InnoplatformException(404, "Telefor raqam yoki parol xato kiritildi!");

        var hasherResult = PasswordHelper.Verify(loginDto.Password, user.Salt, user.Password);
        if (hasherResult == false)
            throw new InnoplatformException(404, "Telefor raqam yoki parol xato kiritildi!");

        return _authService.GenerateToken(user);
    }
}
