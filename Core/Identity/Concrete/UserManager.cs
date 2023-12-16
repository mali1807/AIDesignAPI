using Core.Identity.Abstract;
using Core.Identity.DTOs.Requests;
using Core.Identity.DTOs.Responses;
using Core.Identity.Entities;
using Core.Identity.ExternalAuthentications;
using Core.Identity.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(UserManager<User> userManager, ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> GoogleLoginAsync(GoogleLoginUserRequest googleLoginUserRequest)
        {
            var info = await GoogleAuthentication.GoogleLoginAsync(googleLoginUserRequest.IdToken);
            User user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            return await CreateUserExternalAsync(user,info);
        }
        //Todo bu kodlar refactor edilmeli
        private async Task<AccessToken> CreateUserExternalAsync(User user,UserLoginInfo info)
        {
            bool isUserExist = user is not null;
            if (!isUserExist)
            {
                user = await _userManager.FindByEmailAsync(user.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = user.Email,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                        
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    isUserExist = identityResult.Succeeded;
                }
                
            }
            if (isUserExist)
            {
                await _userManager.AddLoginAsync(user, info);
                var roles = await _userManager.GetRolesAsync(user);

                AccessToken token = _tokenHelper.CreateToken(user, roles);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }
    }
}