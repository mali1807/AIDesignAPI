using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Roles
{
    public class UpdateRoleRequest
    {
        public string UserId { get; set; }
        //Todo Not name, it should role id
        public string RoleName{ get; set; }
    }
}
