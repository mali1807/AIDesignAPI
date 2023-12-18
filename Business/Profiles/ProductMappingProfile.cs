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

namespace Business.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            //Create
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Product>, Paginate<GetListProductResponse>>().ReverseMap();
            CreateMap<Product, GetListProductResponse>().ReverseMap();

            //PermanentDelete
            CreateMap<PermanentDeleteProductResponse, Product>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteProductResponse, Product>().ReverseMap();

            //Update
            CreateMap<UpdateProductRequest, Product>().ForAllMembers(opts=>opts.Condition((src,des,srcMember)=>srcMember !=null));
            CreateMap<UpdateProductResponse, Product>().ReverseMap();
        }
    }
}
