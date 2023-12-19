using Business.DTOs.Requests.BasketItems;
using Business.DTOs.Responses.BasketItems;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketItemService
    {
        Task<CreateBasketItemResponse> CreateBasketItemAsync(CreateBasketItemRequest createBasketItemRequest);
        Task<IPaginate<GetListBasketItemResponse>> GetListBasketItemAsync(PageRequest pageRequest);
        Task<PermanentDeleteBasketItemResponse> PermanentDeleteBasketItemAsync(PermanentDeleteBasketItemRequest permanentDeleteBasketItemRequest);
        Task<SoftDeleteBasketItemResponse> SoftDeleteBasketItemAsync(SoftDeleteBasketItemRequest softDeleteBasketItemRequest);
        Task<UpdateBasketItemResponse> UpdateBasketItemAsync(UpdateBasketItemRequest updateBasketItemRequest);
    }
}
