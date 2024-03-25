using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Auth
{
    public class RemoveRoleRequest
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
