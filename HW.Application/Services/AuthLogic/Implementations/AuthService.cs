using HW.Application.Interfaces;
using HW.Application.Services.AuthLogic.Exceptions;
using HW.Application.Services.AuthLogic.Interfaces;
using HW.ApplicationDTOs.AuthDTOs;
using HW.Core.Entities;
using HW.Core.Stores;
using HW.Core.ValueObjects;

namespace HW.Application.Services.AuthLogic.Implementations;

public class AuthService : IAuthService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;

    public AuthService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUserRepository userStore, ICompanyRepository companyStore,
        IAccountRepository accountStore)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _userRepository = userStore;
        _companyRepository = companyStore;
        _accountRepository = accountStore;
    }

    public async Task<Guid> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
    {
        var account = await _accountRepository.ExistsByEmailAsync(userRegisterDTO.Email);

        if (account == true)
        {
            throw new ExistingUserException();
        }

        var emailVo = Email.Create(userRegisterDTO.Email);
        var phoneVo = PhoneNumber.Create(userRegisterDTO.PhoneNumber);
        var fullNameVo = FullName.Create(userRegisterDTO.FirstName, userRegisterDTO.SecondName, userRegisterDTO.Patronymic);

        var hashedPassword = _passwordHasher.GenerateHash(userRegisterDTO.Password);

        var user = User.Register(emailVo, phoneVo, fullNameVo, hashedPassword);

        var id = await _userRepository.CreateAsync(user);
        return id;
    }

    public async Task<Guid> RegisterCompanyAsync(CompanyRegisterDTO companyRegisterDTO)
    {
        var account = await _accountRepository.ExistsByEmailAsync(companyRegisterDTO.Email);

        if (account == true)
        {
            throw new ExistingUserException();
        }

        var emailVo = Email.Create(companyRegisterDTO.Email);
        var phoneVo = PhoneNumber.Create(companyRegisterDTO.PhoneNumber);

        var hashedPassword = _passwordHasher.GenerateHash(companyRegisterDTO.Password);

        var company = Company.Register(emailVo, phoneVo, companyRegisterDTO.CompanyName, hashedPassword);

        var id = await _companyRepository.CreateAsync(company);
        return id;
    }

    public async Task<string> LoginAsync(LoginDTO loginDTO)
    {
        var account = await _accountRepository.GetByEmailAsync(loginDTO.Email);

        _passwordHasher.VerifyPassword(loginDTO.Password, account.PasswordHash);

        var token = _jwtProvider.GenerateToken(account.Id);
        return token;
    }

    public bool CanChangeAccountInfo(Guid currentUserId, Guid accountId)
    {
        if(accountId == currentUserId)
            return true;

        return false;
    }
}