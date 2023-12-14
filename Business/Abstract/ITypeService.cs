using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Types;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITypeService
    {
        Task<CreateTypeResponse> CreateTypeAsync(CreateTypeRequest createTypeRequest);
        Task<IPaginate<GetListTypeResponse>> GetListTypeAsync(PageRequest pageRequest);
    }
}
