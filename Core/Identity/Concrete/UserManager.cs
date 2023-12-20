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
            return user is null 
                ? await CreateUserExternalAsync(googleLoginUserRequest, info) 
                : await LoginUserExternalAsync(user, info);
        }
        //Todo UserManager sınıfını şimdilik burda, bu isim ile tutuyorum.
        //      Bu aşamada business'e uğramadan işlmler yapılıyor
        //      Şuan burada yazılan kodlar ortakmış gibi duruyor, 
        //      Özelleştirme ya da iş kodları eklemek gerektiğinde burası değiştirilmeli

        //Todo bu kodlar refactor edilmeli
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
            return identityResult.Succeeded 
                ? await LoginUserExternalAsync(newUser, info) 
                : throw new Exception($"Failed to add user to database, {identityResult.Errors}");
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