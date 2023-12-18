using AutoMapper;
using Business.DTOs.Requests.Drafts;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Drafts;
using Business.DTOs.Responses.Types;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class DraftMappingProfile:Profile
    {
        public DraftMappingProfile()
        {
            //CreateType
            CreateMap<Draft, CreateDraftRequest>().ReverseMap();
            CreateMap<Draft, CreateDraftResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Draft>, Paginate<GetListDraftResponse>>().ReverseMap();
            CreateMap<Draft, GetListDraftResponse>().ReverseMap();
        }
        
    }
}
