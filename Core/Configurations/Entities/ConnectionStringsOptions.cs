using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations.Entities
{
    public class ConnectionStringsOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";

        public string PostgreSQL { get; set; }
        public string MongoDB { get; set; }
    }
}
