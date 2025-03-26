using HW.Application.Interfaces;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.ApplicationDTOs.AuthDTOs;
using HW.Core.Entities;
using HW.Core.Stores;
using HW.Core.ValueObjects;
using System.Numerics;

namespace HW.Application.Services.AuthLogic.Implementations;

public class AuthService : IAuthService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccountStore _accountStore;
    private readonly IUserStore _userStore;
    //private readonly ICompanyStore _companyStore;

    public AuthService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUserStore userStore,
        IAccountStore accountStore)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _userStore = userStore;
        //_companyStore = companyStore;
        _accountStore = accountStore;
    }

    public async Task<Guid> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
    {
        var emailVo = Email.Create(userRegisterDTO.Email);
        var phoneVo = PhoneNumber.Create(userRegisterDTO.PhoneNumber);
        var fullNameVo = FullName.Create(userRegisterDTO.FirstName, userRegisterDTO.SecondName, userRegisterDTO.Patronymic);

        var hashedPassword = _passwordHasher.GenerateHash(userRegisterDTO.Password);

        var user = User.Register(emailVo, phoneVo, fullNameVo, hashedPassword);

        var id = await _userStore.CreateAsync(user);
        return id;
    }

    public async Task<string> LoginAsync(LoginDTO loginDTO)
    {
        var account = await _accountStore.GetByEmailAsync(loginDTO.Email);

        _passwordHasher.VerifyPassword(loginDTO.Password, account.PasswordHash);

        var token = _jwtProvider.GenerateToken(account.Id);
        return token;
    }
}