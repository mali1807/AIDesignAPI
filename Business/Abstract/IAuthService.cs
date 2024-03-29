﻿using Business.DTOs.Requests.Auth;
using Business.DTOs.Responses.Auth;
using Core.Identity.DTOs.Requests;
using Core.Identity.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<AccessToken> GoogleLoginAsync(GoogleLoginUserRequest loginUserRequest);
        Task<AssignRoleResponse> AssignRoleToUser(AssignRoleRequest request);
        Task<RemoveRoleResponse> RemoveRoleToUser(RemoveRoleRequest request);
    }
}
