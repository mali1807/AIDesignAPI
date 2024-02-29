using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Identity.Entities;

namespace Business.Helpers.Baskets
{
    public interface IBasketHelper
    {
        Task<Order> CloseBasketAsync(Basket basket);
        Task CreateNewActiveBasket(User user);
        Task CalculateAddedBasketItemAsync(BasketItem basketItem);
        Task CalculateRemovedBasketItemAsync(BasketItem basketItem);
    }
}
