using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Auth
{
    public class RemoveRoleResponse
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
