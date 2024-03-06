using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Images;
using Business.DTOs.Requests.Roles;
using Business.DTOs.Responses.Images;
using Business.DTOs.Responses.Roles;
using Core.Identity.Entities;
using Entities.Concrete;
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
        private readonly IMapper _mapper;
        public RoleManager(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            Role role = new()
            {
                Name = request.Name
            };
            var creatrole = _mapper.Map<Role>(request);
            var result = await _roleManager.CreateAsync(creatrole);
            return _mapper.Map<CreateRoleResponse>(result);
            //return result.Succeeded ? new() { Name = role.Name } : throw new Exception("Role wasn't added");
        }

        public async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role == null)
                throw new Exception("Role wasn't finded");

            var deleterole = _mapper.Map<Role>(request);
            var result = await _roleManager.DeleteAsync(deleterole);
            return _mapper.Map<DeleteRoleResponse>(result);
            //return result.Succeeded ? new() { Name = role.Name } : throw new Exception("Role wasn't deleted");
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