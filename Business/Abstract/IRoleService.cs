using Business.DTOs.Requests.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService 
    {
            Task<bool> CreateRoleAsync(CreateRoleRequest request);
            Task<bool> DeleteRoleAsync(DeleteRoleRequest request);
            Task<bool> ChangeUserRoleAsync(string userId, string newRoleName);
       
    }
}
