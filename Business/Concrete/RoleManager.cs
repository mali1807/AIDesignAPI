using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Images;
using Business.DTOs.Requests.Roles;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Images;
using Business.DTOs.Responses.Roles;
using Business.DTOs.Responses.Types;
using Core.Aspects.Autofac.Security;
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

        //[SecuredOperation("admin")]
        public async Task<CreateRoleResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            var creatRole = _mapper.Map<Role>(request);
            var result = await _roleManager.CreateAsync(creatRole);
            return _mapper.Map<CreateRoleResponse>(result);
        }

        public async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null) throw new Exception("Role wasn't finded");
            var result = await _roleManager.DeleteAsync(role);
            return _mapper.Map<DeleteRoleResponse>(result);
        }

        public async Task<UpdateRoleResponse> ChangeUserRoleAsync(UpdateRoleRequest request)
        {
            var requestedType = await _roleManager.FindByIdAsync(request.Id);
            requestedType = _mapper.Map(request, requestedType);
            await _roleManager.UpdateAsync(requestedType);
            return _mapper.Map<UpdateRoleResponse>(requestedType);
        }
    }
}
