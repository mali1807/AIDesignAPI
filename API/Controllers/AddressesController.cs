using Business.Abstract;
using Business.DTOs.Requests.Addresses;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] CreateAddressRequest request)
        {
            var result=await _addressService.CreateAddressAsync(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListAddresses([FromQuery] PageRequest request)
        {
            var result = await _addressService.GetListAddressAsync(request);
            return Ok(result); 
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftlyDeleteAddress([FromRoute] SoftDeleteAddressRequest request)
        {
            var result =await _addressService.SoftDeleteAddressAsync(request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> PermanentlyDeleteAddress([FromRoute] PermanentDeleteAddressRequest request)
        {
            var result=await _addressService.PermanentDeleteAddressAsync(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequest request)
        {
            var result =await _addressService.UpdateAddressAsync(request);
            return Ok(result);
        }
    }
}
