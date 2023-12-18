using Core.Identity.DTOs.Responses;
using Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity.Jwt
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(User user, IList<string> roles);
    }
}
