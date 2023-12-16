using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations.Entities
{
    public class ExternalLoginSettingsOptions
    {
        public const string ExternalLoginSettings = "ExternalLoginSettings";
        public GoogleLoginOptions Google { get; set; }
    }

    public class GoogleLoginOptions
    {
        public const string Google = "Google";
        public string Client_ID { get; set; }
    }
}
