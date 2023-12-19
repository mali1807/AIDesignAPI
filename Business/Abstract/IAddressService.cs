using Business.DTOs.Requests.Addresses;
using Business.DTOs.Responses.Addresses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest createAddressRequest);
        Task<IPaginate<GetListAddressResponse>> GetListAddressAsync(PageRequest pageRequest);
        Task<PermanentDeleteAddressResponse> PermanentDeleteAddressAsync(PermanentDeleteAddressRequest permanentDeleteAddressRequest);
        Task<SoftDeleteAddressResponse> SoftDeleteAddressAsync(SoftDeleteAddressRequest softDeleteAddressRequest);
        Task<UpdateAddressResponse> UpdateAddressAsync(UpdateAddressRequest updateAddressRequest);
    }
}
