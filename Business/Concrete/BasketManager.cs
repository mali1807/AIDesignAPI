using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Baskets;
using Business.DTOs.Responses.Baskets;
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
    public class BasketManager : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketManager(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<CreateBasketResponse> CreateBasketAsync(CreateBasketRequest createBasketRequest)
        {
            var basket = _mapper.Map<Basket>(createBasketRequest);
            var createdBasket = await _basketRepository.AddAsync(basket);
            return _mapper.Map<CreateBasketResponse>(createdBasket);
        }

        public async Task<IPaginate<GetListBasketResponse>> GetListBasketAsync(PageRequest pageRequest)
        {
            var baskets = await _basketRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListBasketResponse>>(baskets);
        }

        public async Task<PermanentDeleteBasketResponse> PermanentDeleteBasketAsync(PermanentDeleteBasketRequest permanentDeleteBasketRequest)
        {
            var selectedBasket = await _basketRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteBasketRequest.Id));
            var deletedBasket = await _basketRepository.DeleteAsync(selectedBasket, permanent: true);
            return _mapper.Map<PermanentDeleteBasketResponse>(deletedBasket);
        }

        public async Task<SoftDeleteBasketResponse> SoftDeleteBasketAsync(SoftDeleteBasketRequest softDeleteBasketRequest)
        {
            var selectedBasket = await _basketRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteBasketRequest.Id));
            var deletedBasket = await _basketRepository.DeleteAsync(selectedBasket, permanent: false);
            return _mapper.Map<SoftDeleteBasketResponse>(deletedBasket);
        }

        public async Task<UpdateBasketResponse> UpdateBasketAsync(UpdateBasketRequest updateBasketRequest)
        {
            var requestedBasket = await _basketRepository.GetAsync(t => t.Id == Guid.Parse(updateBasketRequest.Id));
            requestedBasket = _mapper.Map(updateBasketRequest, requestedBasket);
            var updatedBasket = await _basketRepository.UpdateAsync(requestedBasket);
            return _mapper.Map<UpdateBasketResponse>(updatedBasket);
        }
    }
}
