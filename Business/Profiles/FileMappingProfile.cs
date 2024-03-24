using AutoMapper;
using Business.DTOs.Requests.Files;
using Business.DTOs.Responses.Files;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concrete.File;

namespace Business.Profiles
{
    public class FileMappingProfile: Profile
    {
        public FileMappingProfile()
        {
            
            CreateMap<File, UploadFileRequest>().ReverseMap();
            CreateMap<File, UploadFileResponse>().ReverseMap();

            //GetList
            CreateMap<IPaginate<File>, Paginate<GetListFileResponse>>().ReverseMap();
            CreateMap<File, GetListFileResponse>().ReverseMap();

            CreateMap<PermanentDeleteFileResponse, File>().ReverseMap();

            //SoftDelete
            CreateMap<SoftDeleteFileResponse, File>().ReverseMap();

            //Update
            CreateMap<UpdateFileRequest, File>().ForAllMembers(opts => opts.Condition((src, des, srcMember) => srcMember != null));
            CreateMap<UpdateFileResponse, File>().ReverseMap();
        }
    }
}
