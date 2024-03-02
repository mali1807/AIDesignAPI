using Business.Abstract;
using Business.DTOs.Requests.Roles;
using Business.DTOs.Responses.Roles;
using Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleManager(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            Role role = new()
            {
                Name = request.Name
            };
            var result = await _roleManager.CreateAsync(role);
            //Todo do mapping
            return result.Succeeded ? new() { Name = role.Name } : throw new Exception("Role wasn't added");
        }

        public async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role == null)
                throw new Exception("Role wasn't finded");

            var result = await _roleManager.DeleteAsync(role);
            //Todo do mapping
            return result.Succeeded ? new() { Name = role.Name } : throw new Exception("Role wasn't deleted");
        }

        public async Task<UpdateRoleResponse> ChangeUserRoleAsync(UpdateRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new Exception("User wasn't finded");

            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!result.Succeeded)
                throw new Exception("Roles wasn't deleted");

            result = await _userManager.AddToRoleAsync(user, request.RoleName);
            //Todo fix this for multiple roles
            return result.Succeeded ? new() { RoleName = request.RoleName,UserId=user.Id.ToString() } : throw new Exception("Role wasn't added to user");
        }
    }
}