using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Configurations.Entities;
using Microsoft.Extensions.Configuration;

namespace Core.Configurations
{
    public static class OptionsConfiguration
    {
        //Burada Configuration Manager class'ı da kullanabiliyor
        //Todo Crud işlemi yapılınca test edilecek
        private static IConfiguration Configuration { get; }
        public static ConnectionStringsOptions ConnectionString
        {
            get
            {
                return Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings).Get<ConnectionStringsOptions>();

            }
        }
    }
}
