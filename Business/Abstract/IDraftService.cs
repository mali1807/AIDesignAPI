using Business.DTOs.Requests.Drafts;
using Business.DTOs.Responses.Drafts;
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
        Task<PermanentDeleteDraftResponse> PermanentDeleteDraftAsync(PermanentDeleteDraftRequest permanentDeleteDraftRequest);
        Task<SoftDeleteDraftResponse> SoftDeleteDraftAsync(SoftDeleteDraftRequest softDeleteDraftRequest);
        Task<UpdateDraftResponse> UpdateDraftAsync(UpdateDraftRequest updateDraftRequest);
    }
}
