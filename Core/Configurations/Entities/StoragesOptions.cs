using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations.Entities
{
    public class StoragesOptions
    {
        public const string Storages = "Storages";
        public string Azure { get; set; }
        public string AWS { get; set; }
        public int Google { get; set; }
    }
}
