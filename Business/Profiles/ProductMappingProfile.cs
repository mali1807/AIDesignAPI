using AutoMapper;
using Business.DTOs.Responses.Products;
using Business.DTOs.Requests.Products;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace Business.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            //CreateType
            CreateMap<Type, CreateProductRequest>().ReverseMap();
            CreateMap<Type, CreateProductResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Type>, Paginate<GetListProductResponse>>().ReverseMap();
            CreateMap<Type, GetListProductResponse>().ReverseMap();

            //PermanentDelete
            CreateMap<PermanentDeleteProductResponse, Type>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteProductResponse, Type>().ReverseMap();

            //Update
            CreateMap<UpdateProductRequest, Type>().ForAllMembers(opts=>opts.Condition((src,des,srcMember)=>srcMember !=null));
            CreateMap<UpdateProductResponse, Type>().ReverseMap();
        }
    }
}
