using HW.Core.Entities;

namespace HW.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(Guid id, string role);
}
