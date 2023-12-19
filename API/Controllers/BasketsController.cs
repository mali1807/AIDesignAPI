using Business.Abstract;
using Business.DTOs.Requests.Baskets;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketRequest request)
        {
            var result=await _basketService.CreateBasketAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListBaskets([FromQuery] PageRequest request)
        {
            var result = await _basketService.GetListBasketAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftlyDeleteBasket([FromRoute] SoftDeleteBasketRequest request)
        {
            var result =await _basketService.SoftDeleteBasketAsync(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> PermanentlyDeleteBasket([FromRoute] PermanentDeleteBasketRequest request)
        {
            var result=await _basketService.PermanentDeleteBasketAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketRequest request)
        {
            var result =await _basketService.UpdateBasketAsync(request);
            return Ok(result);
        }
    }
}
