using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Roles
{
    public class UpdateRoleResponse
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
    }
}
