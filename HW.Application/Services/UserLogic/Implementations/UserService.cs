using HW.Application.Services.UserLogic.Interfaces;
using HW.ApplicationDTOs.UserDTOs;
using HW.Core.Stores;

namespace HW.Application.Services.UserLogic.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userStore)
    {
       _userRepository = userStore;
    }

    public async Task<UserInfoDTO> GetUserInfoAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        var userDTO = new UserInfoDTO()
        {
            FirstName = user.FullName.FirstName,
            SecondName = user.FullName.SecondName,
            Patronymic = user.FullName.Patronymic,
            PhoneNumber = user.PhoneNumber.Value,
            Description = user.Description,
            Email = user.Email.Value,
        };

        return userDTO;
    }

    public async Task<UserInfoDTO> PatchUserInfoAsync(UserPatchDTO patchUserInfo, Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (patchUserInfo.FirstName != null
            || patchUserInfo.SecondName != null
            || patchUserInfo.Patronymic != null)
        {
            var fullName = user.FullName;
            user.UpdateFullName(
                patchUserInfo.FirstName ?? fullName.FirstName,
                patchUserInfo.SecondName ?? fullName.SecondName,
                patchUserInfo.Patronymic ?? fullName.Patronymic
            );
        }

        if (patchUserInfo.Email != null)
            user.UpdateEmail(patchUserInfo.Email);

        if(patchUserInfo.PhoneNumber != null)
            user.UpdatePhoneNumber(patchUserInfo.PhoneNumber);

        if(patchUserInfo.Description != null)
            user.UpdateDescription(patchUserInfo.Description);

        await _userRepository.UpdateAsync(user);

        var patchedUserDTO = new UserInfoDTO()
        {
            FirstName = user.FullName.FirstName,
            SecondName = user.FullName.SecondName,
            Patronymic = user.FullName.Patronymic,
            PhoneNumber = user.PhoneNumber.Value,
            Description = user.Description,
            Email = user.Email.Value,
        };

        return patchedUserDTO;
    }
}