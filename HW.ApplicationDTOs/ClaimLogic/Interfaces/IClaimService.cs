namespace HW.ApplicationDTOs.ClaimLogic.Interfaces;

public interface IClaimService
{
    Guid TryParseGuidClaim(string? GuidClaim);
}
