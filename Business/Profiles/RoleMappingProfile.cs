using AutoMapper;
using Business.DTOs.Requests.Roles;
using Business.DTOs.Responses.Roles;
using Core.Identity.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class RoleMappingProfile :  Profile
    {
        public RoleMappingProfile() 
        { 
        CreateMap<Role, CreateRoleRequest>().ReverseMap();
        CreateMap<IdentityResult, CreateRoleResponse>().ForMember(res=>res.IsSucceeded,opt=>opt.MapFrom(r=>r.Succeeded))
                .ReverseMap();

            //delete
            CreateMap<IdentityResult, DeleteRoleResponse>().ForMember(res => res.IsSucceeded, opt => opt.MapFrom(r => r.Succeeded))
                .ReverseMap();

        //Update
        CreateMap<UpdateRoleRequest, Role>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
        CreateMap<UpdateRoleResponse, IdentityResult>().ReverseMap();
        }
       
    }
}
