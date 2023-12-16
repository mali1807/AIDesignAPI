using Core.Identity.DTOs.Requests;
using Core.Identity.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity.Abstract
{
    public interface IUserService
    {
        Task<AccessToken> GoogleLoginAsync(GoogleLoginUserRequest loginUserRequest);
    }
}
