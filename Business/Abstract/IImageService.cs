using Business.DTOs.Requests.Images;
using Business.DTOs.Responses.Images;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        Task<List<UploadImageResponse>> UploadImageAsync(UploadImageRequest uploadImageRequest);
        Task<IPaginate<GetListImageResponse>> GetListImageAsync(PageRequest pageRequest);
        Task<PermanentDeleteImageResponse> PermanentDeleteImageAsync(PermanentDeleteImageRequest permanentDeleteImageRequest);
        Task<SoftDeleteImageResponse> SoftDeleteImageAsync(SoftDeleteImageRequest softDeleteImageRequest);
        Task<UpdateImageResponse> UpdateImageAsync(UpdateImageRequest updateImageRequest);
    }
}
