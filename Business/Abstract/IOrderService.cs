using Business.DTOs.Requests.Orders;
using Business.DTOs.Responses.Orders;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest);
        Task<IPaginate<GetListOrderResponse>> GetListOrderAsync(PageRequest pageRequest);
        Task<PermanentDeleteOrderResponse> PermanentDeleteOrderAsync(PermanentDeleteOrderRequest permanentDeleteOrderRequest);
        Task<SoftDeleteOrderResponse> SoftDeleteOrderAsync(SoftDeleteOrderRequest softDeleteOrderRequest);
        Task<UpdateOrderResponse> UpdateOrderAsync(UpdateOrderRequest updateOrderRequest);
    }
}
