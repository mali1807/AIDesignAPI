using Autofac.Core;
using Business.Abstract;
using Business.DTOs.Requests.Products;
using Business.DTOs.Requests.Types;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]CreateProductRequest request)
        {
            var result= await _productService.CreateProductAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts([FromQuery] PageRequest request)
        {
            var result= await _productService.GetListProductAsync(request);
            return Ok(result);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> SoftlyDeleteProduct([FromRoute] SoftDeleteProductRequest request)
        {
            var result = await _productService.SoftDeleteProductAsync(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> PermanentlyDeleteProduct([FromRoute] PermanentDeleteProductRequest request)
        {
            var result = await _productService.PermanentDeleteProductAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var result = await _productService.UpdateProductAsync(request);
            return Ok(result);
        }
    }
}
