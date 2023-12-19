using AutoMapper;
using Business.DTOs.Requests.BasketItems;
using Business.DTOs.Responses.BasketItems;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BasketItemMappingProfile : Profile
    {
        public BasketItemMappingProfile()
        {
            
            CreateMap<BasketItem, CreateBasketItemRequest>().ReverseMap();
            CreateMap<BasketItem, CreateBasketItemResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<BasketItem>, Paginate<GetListBasketItemResponse>>().ReverseMap();
            CreateMap<BasketItem, GetListBasketItemResponse>().ReverseMap();

            CreateMap<PermanentDeleteBasketItemResponse, BasketItem>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteBasketItemResponse, BasketItem>().ReverseMap();

            //Update
            CreateMap<UpdateBasketItemRequest, BasketItem>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateBasketItemResponse, BasketItem>().ReverseMap();
        }
    }
}
