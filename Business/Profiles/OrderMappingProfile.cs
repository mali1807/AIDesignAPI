using AutoMapper;
using Business.DTOs.Requests.Orders;
using Business.DTOs.Responses.Orders;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class OrderMappingProfile: Profile
    {
        public OrderMappingProfile()
        {
            
            CreateMap<Order, CreateOrderRequest>().ReverseMap();
            CreateMap<Order, CreateOrderResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Order>, Paginate<GetListOrderResponse>>().ReverseMap();
            CreateMap<Order, GetListOrderResponse>().ReverseMap();

            CreateMap<PermanentDeleteOrderResponse, Order>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteOrderResponse, Order>().ReverseMap();

            //Update
            CreateMap<UpdateOrderRequest, Order>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateOrderResponse, Order>().ReverseMap();
        }
    }
}
