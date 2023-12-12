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
        public static string ConnectionString
        {
            get
            {
                //Todo Burada connection'ı appsettings'den çekemedim
                return "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=AIDesignDb;";

            }
        }
    }
}
