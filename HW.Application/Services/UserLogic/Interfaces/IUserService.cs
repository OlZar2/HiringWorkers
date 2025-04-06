using HW.ApplicationDTOs.UserDTOs;

namespace HW.Application.Services.UserLogic.Interfaces;

public interface IUserService
{
    Task<UserInfoDTO> GetUserInfoAsync(Guid userId);
    Task<UserInfoDTO> PatchUserInfoAsync(UserPatchDTO patchUserInfo, Guid userId);
}
