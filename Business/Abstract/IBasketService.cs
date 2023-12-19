using Business.DTOs.Requests.Baskets;
using Business.DTOs.Responses.Baskets;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketService
    {
        Task<CreateBasketResponse> CreateBasketAsync(CreateBasketRequest createBasketRequest);
        Task<IPaginate<GetListBasketResponse>> GetListBasketAsync(PageRequest pageRequest);
        Task<PermanentDeleteBasketResponse> PermanentDeleteBasketAsync(PermanentDeleteBasketRequest permanentDeleteBasketRequest);
        Task<SoftDeleteBasketResponse> SoftDeleteBasketAsync(SoftDeleteBasketRequest softDeleteBasketRequest);
        Task<UpdateBasketResponse> UpdateBasketAsync(UpdateBasketRequest updateBasketRequest);
    }
}
