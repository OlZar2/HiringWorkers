using HW.Application.Services.AuthLogic.Exceptions;
using HW.Application.Services.AuthLogic.Interfaces;

namespace HW.Application.Services.AuthLogic.Implementations;

public class PasswordHasher : IPasswordHasher
{
    public string GenerateHash(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public void VerifyPassword(string password, string hashedPassword)
    {
        var isPasswodVerified = BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        if (!isPasswodVerified)
            throw new WrongPasswordException();
    }
}
