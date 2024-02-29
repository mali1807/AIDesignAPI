using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using Core.Identity.Entities;
using Core.DataAccess.Paging;
using Microsoft.EntityFrameworkCore;

namespace Business.Helpers.Baskets
{
    public class BasketHelper:  IBasketHelper
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketHelper(IOrderRepository orderRepository, IBasketRepository basketRepository, IBasketItemRepository basketItemRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<Order> CloseBasketAsync(Basket basket)
        {
            Order order = await CreateOrderAsync(basket);
            await CloseActiveBasketAsync(basket);
            await CreateNewActiveBasket(basket);
            return order;
        }
        private async Task<Order> CreateOrderAsync(Basket basket)
        {
            Order order = new() { BasketId = basket.Id, Basket = basket };
            Order addedOrder = await _orderRepository.AddAsync(order);
            return addedOrder;
        }

        private async Task CloseActiveBasketAsync(Basket basket)
        {
            basket.IsActive = false;
            await _basketRepository.UpdateAsync(basket);
        }

        private async Task CreateNewActiveBasket(Basket basket)
        {
            Basket newBasket = new()
            {
                CreatedDate = DateTime.Now,
                IsActive = true,
                Status = true,
                TotalPrice = 0,
                TotalProduct = 0,
                User = basket.User,
                UserId = basket.UserId,
            };
            await _basketRepository.AddAsync(newBasket);
        }

        public async Task CreateNewActiveBasket(User user)
        {
            Basket newBasket = new()
            {
                CreatedDate = DateTime.Now,
                IsActive = true,
                Status = true,
                TotalPrice = 0,
                TotalProduct = 0,
                User = user,
                UserId = user.Id,
            };
            await _basketRepository.AddAsync(newBasket);
        }

        public async Task CalculateAddedBasketItemAsync(BasketItem basketItem)
        {
            IPaginate<BasketItem> basketItems = await _basketItemRepository.GetListAsync(b => b.Id == basketItem.Id, include: b => b.Include(x=>x.Product));
            await AddTotalPriceAsync(basketItems.Items.FirstOrDefault());
            await AddTotalProductAsync(basketItems.Items.FirstOrDefault());
        }

        private async Task AddTotalPriceAsync(BasketItem basketItem)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.Id == basketItem.BasketId);
            basket.TotalPrice += basketItem.Product.Price * basketItem.Quantity;
            Basket updatedBasket = await _basketRepository.UpdateAsync(basket);

        }

        private async Task AddTotalProductAsync(BasketItem basketItem)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.Id == basketItem.BasketId);
            basket.TotalProduct += basketItem.Quantity;
            Basket updatedBasket = await _basketRepository.UpdateAsync(basket);
        }

        public async Task CalculateRemovedBasketItemAsync(BasketItem basketItem)
        {
            IPaginate<BasketItem> basketItems = await _basketItemRepository.GetListAsync(b => b.Id == basketItem.Id, include: b => b.Include(p => p.Product));
            await RemoveTotalPriceAsync(basketItems.Items.FirstOrDefault());
            await RemoveTotalProductAsync(basketItems.Items.FirstOrDefault());
        }

        private async Task RemoveTotalPriceAsync(BasketItem basketItem)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.Id == basketItem.BasketId);
            basket.TotalPrice -= basketItem.Product.Price * basketItem.Quantity;
            Basket updatedBasket = await _basketRepository.UpdateAsync(basket);
        }

        private async Task RemoveTotalProductAsync(BasketItem basketItem)
        {
            Basket basket = await _basketRepository.GetAsync(b => b.Id == basketItem.BasketId);
            basket.TotalProduct -= basketItem.Quantity;
            Basket updatedBasket = await _basketRepository.UpdateAsync(basket);
        }
    }
}
