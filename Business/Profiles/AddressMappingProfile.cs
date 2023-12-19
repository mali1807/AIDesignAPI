using AutoMapper;
using Business.DTOs.Requests.Addresses;
using Business.DTOs.Responses.Addresses;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AddressMappingProfile: Profile
    {
        public AddressMappingProfile()
        {
            
            CreateMap<Address, CreateAddressRequest>().ReverseMap();
            CreateMap<Address, CreateAddressResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Address>, Paginate<GetListAddressResponse>>().ReverseMap();
            CreateMap<Address, GetListAddressResponse>().ReverseMap();

            CreateMap<PermanentDeleteAddressResponse, Address>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteAddressResponse, Address>().ReverseMap();

            //Update
            CreateMap<UpdateAddressRequest, Address>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateAddressResponse, Address>().ReverseMap();
        }
    }
}
