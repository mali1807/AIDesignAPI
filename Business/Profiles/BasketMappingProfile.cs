using AutoMapper;
using Business.DTOs.Requests.Baskets;
using Business.DTOs.Responses.Baskets;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BasketMappingProfile: Profile
    {
        public BasketMappingProfile()
        {
            
            CreateMap<Basket, CreateBasketRequest>().ReverseMap();
            CreateMap<Basket, CreateBasketResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Basket>, Paginate<GetListBasketResponse>>().ReverseMap();
            CreateMap<Basket, GetListBasketResponse>().ReverseMap();

            CreateMap<PermanentDeleteBasketResponse, Basket>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteBasketResponse, Basket>().ReverseMap();

            //Update
            CreateMap<UpdateBasketRequest, Basket>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateBasketResponse, Basket>().ReverseMap();
        }
    }
}
