using AutoMapper;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Types;
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
    public class TypeMappingProfile : Profile
    {
        public TypeMappingProfile()
        {
            //CreateType
            CreateMap<Type, CreateTypeRequest>().ReverseMap();
            CreateMap<Type, CreateTypeResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Type>, Paginate<GetListTypeResponse>>().ReverseMap();
            CreateMap<Type, GetListTypeResponse>().ReverseMap();

            //PermanentDelete
            CreateMap<PermanentDeleteTypeResponse, Type>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteTypeResponse, Type>().ReverseMap();

            //Update
            CreateMap<UpdateTypeRequest, Type>().ForAllMembers(opts=>opts.Condition((src,des,srcMember)=>srcMember !=null));
            CreateMap<UpdateTypeResponse, Type>().ReverseMap();
        }
    }
}
