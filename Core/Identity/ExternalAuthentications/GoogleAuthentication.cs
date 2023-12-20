using Core.Configurations;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity.ExternalAuthentications
{
    public static class GoogleAuthentication
    {
        private const string Google = "GOOGLE";
        public async static Task<UserLoginInfo> GoogleLoginAsync(string token)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { OptionsConfiguration.GoogleLogin.Client_ID },
                
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);

            return new UserLoginInfo(Google, payload.Subject, Google);
        }
    }
}
