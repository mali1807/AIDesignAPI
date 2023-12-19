using Business.DTOs.Requests.Files;
using Business.DTOs.Responses.Files;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        Task<CreateFileResponse> CreateFileAsync(CreateFileRequest createFileRequest);
        Task<IPaginate<GetListFileResponse>> GetListFileAsync(PageRequest pageRequest);
        Task<PermanentDeleteFileResponse> PermanentDeleteFileAsync(PermanentDeleteFileRequest permanentDeleteFileRequest);
        Task<SoftDeleteFileResponse> SoftDeleteFileAsync(SoftDeleteFileRequest softDeleteFileRequest);
        Task<UpdateFileResponse> UpdateFileAsync(UpdateFileRequest updateFileRequest);
    }
}
