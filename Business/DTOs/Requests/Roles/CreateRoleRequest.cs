using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Roles
{
    public class CreateRoleRequest
    {
        
        public string roleName{ get; set; }
        public string normalizedName { get; set; }
    }
}
