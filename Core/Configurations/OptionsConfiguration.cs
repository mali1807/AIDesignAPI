using Core.Configurations.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations
{
    public static class OptionsConfiguration
    {
        private static ConfigurationManager GetAppSettingsFile()
        {
            //Todo refactor edilebilir mi bak
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager;
        }
        public static ConnectionStringsOptions ConnectionString
        {
            get
            {
                return GetAppSettingsFile().GetSection(ConnectionStringsOptions.ConnectionStrings).Get<ConnectionStringsOptions>();
            }
        }

        public static GoogleLoginOptions GoogleLogin
        {
            get
            {
                return GetAppSettingsFile().GetSection(ExternalLoginSettingsOptions.ExternalLoginSettings)
                    .GetSection(GoogleLoginOptions.Google).Get<GoogleLoginOptions>();
            }
        }

        public static TokenOptions Token
        {
            get
            {
                return GetAppSettingsFile().GetSection(TokenOptions.Token).Get<TokenOptions>();
            }
        }
    }
}
