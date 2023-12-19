using AutoMapper;
using Business.DTOs.Requests.DraftImages;
using Business.DTOs.Responses.DraftImages;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class DraftImageMappingProfile: Profile
    {
        public DraftImageMappingProfile()
        {
            
            CreateMap<DraftImage, CreateDraftImageRequest>().ReverseMap();
            CreateMap<DraftImage, CreateDraftImageResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<DraftImage>, Paginate<GetListDraftImageResponse>>().ReverseMap();
            CreateMap<DraftImage, GetListDraftImageResponse>().ReverseMap();

            CreateMap<PermanentDeleteDraftImageResponse, DraftImage>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteDraftImageResponse, DraftImage>().ReverseMap();

            //Update
            CreateMap<UpdateDraftImageRequest, DraftImage>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateDraftImageResponse, DraftImage>().ReverseMap();
        }
    }
}
