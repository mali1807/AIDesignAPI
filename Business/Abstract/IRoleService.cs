using Business.DTOs.Requests.Roles;
using Business.DTOs.Responses.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService 
    {
            Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request);
            Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request);
            Task<UpdateRoleResponse> ChangeUserRoleAsync(UpdateRoleRequest request);
       
    }
}
