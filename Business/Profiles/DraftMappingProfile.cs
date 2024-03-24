using AutoMapper;
using Business.DTOs.Requests.Drafts;
using Business.DTOs.Responses.Drafts;
using Core.DataAccess.Paging;
using Entities.Concrete;

namespace Business.Profiles
{
    public class DraftMappingProfile:Profile
    {
        public DraftMappingProfile()
        {
            //CreateDraft
            CreateMap<Draft, CreateDraftRequest>().ReverseMap();
            CreateMap<Draft, CreateDraftResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Draft>, Paginate<GetListDraftResponse>>().ReverseMap();
            CreateMap<Draft, GetListDraftResponse>().ReverseMap();

            //PermanentDelete
            CreateMap<PermanentDeleteDraftResponse, Draft>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteDraftResponse, Draft>().ReverseMap();

            //Update
            CreateMap<UpdateDraftRequest, Draft>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateDraftResponse, Draft>().ReverseMap();
        }
        
    }
}
