using Business.Abstract;
using Business.DTOs.Requests.Orders;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderRequest request)
        {
            var result=await _orderService.CreateOrderAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListOrders([FromQuery] PageRequest request)
        {
            var result = await _orderService.GetListOrderAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftlyDeleteOrder([FromRoute] SoftDeleteOrderRequest request)
        {
            var result =await _orderService.SoftDeleteOrderAsync(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> PermanentlyDeleteOrder([FromRoute] PermanentDeleteOrderRequest request)
        {
            var result=await _orderService.PermanentDeleteOrderAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest request)
        {
            var result =await _orderService.UpdateOrderAsync(request);
            return Ok(result);
        }
    }
}
