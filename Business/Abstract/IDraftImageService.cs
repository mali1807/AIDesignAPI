using Business.DTOs.Requests.DraftImages;
using Business.DTOs.Responses.DraftImages;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDraftImageService
    {
        Task<CreateDraftImageResponse> CreateDraftImageAsync(CreateDraftImageRequest createDraftImageRequest);
        Task<IPaginate<GetListDraftImageResponse>> GetListDraftImageAsync(PageRequest pageRequest);
        Task<PermanentDeleteDraftImageResponse> PermanentDeleteDraftImageAsync(PermanentDeleteDraftImageRequest permanentDeleteDraftImageRequest);
        Task<SoftDeleteDraftImageResponse> SoftDeleteDraftImageAsync(SoftDeleteDraftImageRequest softDeleteDraftImageRequest);
        Task<UpdateDraftImageResponse> UpdateDraftImageAsync(UpdateDraftImageRequest updateDraftImageRequest);
    }
}
