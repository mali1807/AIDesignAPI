using AutoMapper;
using Business.DTOs.Requests.Images;
using Business.DTOs.Responses.Images;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {

            CreateMap<Image, UploadImageRequest>().ReverseMap();
            CreateMap<Image, UploadImageResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<Image>, Paginate<GetListImageResponse>>().ReverseMap();
            CreateMap<Image, GetListImageResponse>().ReverseMap();

            CreateMap<PermanentDeleteImageResponse, Image>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteImageResponse, Image>().ReverseMap();

            //Update
            CreateMap<UpdateImageRequest, Image>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateImageResponse, Image>().ReverseMap();
        }
    }
}
