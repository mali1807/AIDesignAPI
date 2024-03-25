using Business.Abstract;
using Business.DTOs.Requests.Auth;
using Business.DTOs.Responses.Auth;
using Business.Helpers.Baskets;
using Core.Identity.DTOs.Requests;
using Core.Identity.DTOs.Responses;
using Core.Identity.Entities;
using Core.Identity.ExternalAuthentications;
using Core.Identity.Jwt;
using DataAccess.Abstract.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITokenHelper _tokenHelper;
        private readonly IBasketHelper _basketHelper;

        public AuthManager(UserManager<User> userManager, ITokenHelper tokenHelper, IBasketHelper basketHelper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
            _basketHelper = basketHelper;
            _roleManager = roleManager;
        }

        public async Task<AssignRoleResponse> AssignRoleToUser(AssignRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User wasn't finded");

            var role = await _roleManager.FindByIdAsync(request.RoleId);
            if (role == null)
                throw new Exception("Role wasn't finded");

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            
            return result.Succeeded ? new() { RoleName = role.Name, Email = user.Email } : throw new Exception("Role wasn't added to user");
        }

        public async Task<AccessToken> GoogleLoginAsync(GoogleLoginUserRequest googleLoginUserRequest)
        {
            var info = await GoogleAuthentication.GoogleLoginAsync(googleLoginUserRequest.IdToken);
            User user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            return user is null
                ? await CreateUserExternalAsync(googleLoginUserRequest, info)
                : await LoginUserExternalAsync(user, info);
        }

        public async Task<RemoveRoleResponse> RemoveRoleToUser(RemoveRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User wasn't finded");

            var role = await _roleManager.FindByIdAsync(request.RoleId);
            if (role == null)
                throw new Exception("Role wasn't finded");

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            return result.Succeeded ? new() { RoleName = role.Name, Email = user.Email } : throw new Exception("Role wasn't removed to user");
        }

        private async Task<AccessToken> CreateUserExternalAsync(GoogleLoginUserRequest user, UserLoginInfo info)
        {
            User newUser = new()
            {
                Email = user.Email,
                UserName = user.Name,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var identityResult = await _userManager.CreateAsync(newUser);

            if (identityResult.Succeeded)
            {
                await _basketHelper.CreateNewActiveBasket(newUser);
                return await LoginUserExternalAsync(newUser, info);
            }

            throw new Exception($"Failed to add user to database, {identityResult.Errors}");

        }
        private async Task<AccessToken> LoginUserExternalAsync(User user, UserLoginInfo info)
        {
            await _userManager.AddLoginAsync(user, info);
            var roles = await _userManager.GetRolesAsync(user);

            AccessToken token = _tokenHelper.CreateToken(user, roles);
            return token;
        }


    }


}