using Business.Abstract;
using Business.DTOs.Requests.BasketItems;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemsController : ControllerBase
    {
        private readonly IBasketItemService _basketItemService;

        public BasketItemsController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBasketItem([FromBody] CreateBasketItemRequest request)
        {
            var result=await _basketItemService.CreateBasketItemAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListBasketItems([FromQuery] PageRequest request)
        {
            var result = await _basketItemService.GetListBasketItemAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteBasketItem([FromRoute] SoftDeleteBasketItemRequest request)
        {
            var result =await _basketItemService.SoftDeleteBasketItemAsync(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteBasketItem([FromRoute] PermanentDeleteBasketItemRequest request)
        {
            var result=await _basketItemService.PermanentDeleteBasketItemAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasketItem([FromBody] UpdateBasketItemRequest request)
        {
            var result =await _basketItemService.UpdateBasketItemAsync(request);
            return Ok(result);
        }
    }
}
