using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Addresses;
using Business.DTOs.Responses.Addresses;
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
    public class AddressManager : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressManager(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest createAddressRequest)
        {
           var address = _mapper.Map<Address>(createAddressRequest);
            var createdAddress = await _addressRepository.AddAsync(address);
            return _mapper.Map<CreateAddressResponse>(createdAddress); 
        }


        public async Task<IPaginate<GetListAddressResponse>> GetListAddressAsync(PageRequest pageRequest)
        {
            var addresses = await _addressRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListAddressResponse>>(addresses);
        }

        public async Task<PermanentDeleteAddressResponse> PermanentDeleteAddressAsync(PermanentDeleteAddressRequest permanentDeleteAddressRequest)
        {
            var selectedAddress = await _addressRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteAddressRequest.Id));
            var deletedAddress = await _addressRepository.DeleteAsync(selectedAddress, permanent: true);
            return _mapper.Map<PermanentDeleteAddressResponse>(deletedAddress);
        }

        public async Task<SoftDeleteAddressResponse> SoftDeleteAddressAsync(SoftDeleteAddressRequest softDeleteAddressRequest)
        {
            var selectedAddress = await _addressRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteAddressRequest.Id));
            var deletedAddress = await _addressRepository.DeleteAsync(selectedAddress, permanent: false);
            return _mapper.Map<SoftDeleteAddressResponse>(deletedAddress);
        }
        public async Task<UpdateAddressResponse> UpdateAddressAsync(UpdateAddressRequest updateAddressRequest)
        {
            var requestedAddress = await _addressRepository.GetAsync(t => t.Id == Guid.Parse(updateAddressRequest.Id));
            requestedAddress = _mapper.Map(updateAddressRequest, requestedAddress);
            var updatedAddress = await _addressRepository.UpdateAsync(requestedAddress);
            return _mapper.Map<UpdateAddressResponse>(updatedAddress);
        }

        public async Task<List<GetByUserIdAddressResponse>> GetByUserIdAddressAsync(GetByUserIdAddressRequest getByUserIdAddressRequest)
        {
            var requestedAddress = await _addressRepository.GetListAsync(a=>a.User.Id==Guid.Parse(getByUserIdAddressRequest.UserId));
            return _mapper.Map<List<GetByUserIdAddressResponse>>(requestedAddress.Items);
        }
    }
}
