using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.BasketItems;
using Business.DTOs.Responses.BasketItems;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BasketItemManager : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public BasketItemManager(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }

        public async Task<CreateBasketItemResponse> CreateBasketItemAsync(CreateBasketItemRequest createBasketItemRequest)
        {
            var basketItem = _mapper.Map<BasketItem>(createBasketItemRequest);
            var createdBasketItem = await _basketItemRepository.AddAsync(basketItem);
            return _mapper.Map<CreateBasketItemResponse>(createdBasketItem);
        }

        public async Task<IPaginate<GetListBasketItemResponse>> GetListBasketItemAsync(PageRequest pageRequest)
        {
            var basketItems = await _basketItemRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListBasketItemResponse>>(basketItems);
        }

        public async Task<PermanentDeleteBasketItemResponse> PermanentDeleteBasketItemAsync(PermanentDeleteBasketItemRequest permanentDeleteBasketItemRequest)
        {
             var selectedBasketItem = await _basketItemRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteBasketItemRequest.Id));
            var deletedBasketItem = await _basketItemRepository.DeleteAsync(selectedBasketItem, permanent: true);
            return _mapper.Map<PermanentDeleteBasketItemResponse>(deletedBasketItem);
        }

        public async Task<SoftDeleteBasketItemResponse> SoftDeleteBasketItemAsync(SoftDeleteBasketItemRequest softDeleteBasketItemRequest)
        {
            var selectedBasketItem = await _basketItemRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteBasketItemRequest.Id));
            var deletedBasketItem = await _basketItemRepository.DeleteAsync(selectedBasketItem, permanent: false);
            return _mapper.Map<SoftDeleteBasketItemResponse>(deletedBasketItem);
        }

        public async Task<UpdateBasketItemResponse> UpdateBasketItemAsync(UpdateBasketItemRequest updateBasketItemRequest)
        {
            var requestedBasketItem = await _basketItemRepository.GetAsync(t => t.Id == Guid.Parse(updateBasketItemRequest.Id));
            requestedBasketItem = _mapper.Map(updateBasketItemRequest, requestedBasketItem);
            var updatedBasketItem = await _basketItemRepository.UpdateAsync(requestedBasketItem);
            return _mapper.Map<UpdateBasketItemResponse>(updatedBasketItem);
        }
    }
}
