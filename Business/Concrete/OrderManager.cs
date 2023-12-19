using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Orders;
using Business.DTOs.Responses.Orders;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest)
        {
             var order = _mapper.Map<Order>(createOrderRequest);
            var createdOrder = await _orderRepository.AddAsync(order);
            return _mapper.Map<CreateOrderResponse>(createdOrder);
        }

        public async Task<IPaginate<GetListOrderResponse>> GetListOrderAsync(PageRequest pageRequest)
        {
            var orders = await _orderRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListOrderResponse>>(orders);
        }

        public async Task<PermanentDeleteOrderResponse> PermanentDeleteOrderAsync(PermanentDeleteOrderRequest permanentDeleteOrderRequest)
        {
            var selectedOrder = await _orderRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteOrderRequest.Id));
            var deletedOrder = await _orderRepository.DeleteAsync(selectedOrder, permanent: true);
            return _mapper.Map<PermanentDeleteOrderResponse>(deletedOrder);
        }

        public async Task<SoftDeleteOrderResponse> SoftDeleteOrderAsync(SoftDeleteOrderRequest softDeleteOrderRequest)
        {
           var selectedOrder = await _orderRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteOrderRequest.Id));
            var deletedOrder = await _orderRepository.DeleteAsync(selectedOrder, permanent: false);
            return _mapper.Map<SoftDeleteOrderResponse>(deletedOrder);
        }
        public async Task<UpdateOrderResponse> UpdateOrderAsync(UpdateOrderRequest updateOrderRequest)
        {
            var requestedOrder = await _orderRepository.GetAsync(t => t.Id == Guid.Parse(updateOrderRequest.Id));
            requestedOrder = _mapper.Map(updateOrderRequest, requestedOrder);
            var updatedOrder = await _orderRepository.UpdateAsync(requestedOrder);
            return _mapper.Map<UpdateOrderResponse>(updatedOrder);
        }
    }
}
