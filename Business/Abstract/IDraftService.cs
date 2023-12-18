using Business.DTOs.Requests.Drafts;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Drafts;
using Business.DTOs.Responses.Types;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDraftService
    {
        Task<CreateDraftResponse> CreateDraftAsync(CreateDraftRequest createDraftRequest);
        Task<IPaginate<GetListDraftResponse>> GetListDraftAsync(PageRequest pageRequest);
    }
}
