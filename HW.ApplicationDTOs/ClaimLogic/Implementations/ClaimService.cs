using HW.ApplicationDTOs.ClaimLogic.Interfaces;

namespace HW.ApplicationDTOs.ClaimLogic.Implementations;

public class ClaimService : IClaimService
{
    public Guid TryParseGuidClaim(string? GuidClaim)
    {
        if (!Guid.TryParse(GuidClaim, out Guid guid))
        {
            throw new ArgumentException("Некорректный Id пользователя");
        }

        return guid;
    }
}
