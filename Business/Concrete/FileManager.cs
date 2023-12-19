using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Files;
using Business.DTOs.Requests.Products;
using Business.DTOs.Responses.Files;
using Business.DTOs.Responses.Products;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concrete.File;


namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public FileManager(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<CreateFileResponse> CreateFileAsync(CreateFileRequest createFileRequest)
        {
            var file = _mapper.Map<File>(createFileRequest);
            var createdFile = await _fileRepository.AddAsync(file);
            return _mapper.Map<CreateFileResponse>(createdFile);    


        }

        public async Task<IPaginate<GetListFileResponse>> GetListFileAsync(PageRequest pageRequest)
        {
            var files = await _fileRepository.GetListAsync(index: pageRequest.PageIndex, size : pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListFileResponse>>(files);
        }

        public async Task<PermanentDeleteFileResponse> PermanentDeleteFileAsync(PermanentDeleteFileRequest permanentDeleteFileRequest)
        {
            var selectedFile = await _fileRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteFileRequest.Id));
            var deletedFile = await _fileRepository.DeleteAsync(selectedFile,permanent:true);
            return _mapper.Map<PermanentDeleteFileResponse>(deletedFile);
        }

        public async Task<SoftDeleteFileResponse> SoftDeleteFileAsync(SoftDeleteFileRequest softDeleteFileRequest)
        {
            var selectedFile = await _fileRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteFileRequest.Id));
            var hidedFile = await _fileRepository.DeleteAsync(selectedFile, permanent: false);
            return _mapper.Map<SoftDeleteFileResponse>(hidedFile);

        }

        public async Task<UpdateFileResponse> UpdateFileAsync(UpdateFileRequest updateFileRequest)
        {
            var requestedFile = await _fileRepository.GetAsync(t => t.Id == Guid.Parse(updateFileRequest.Id));
            requestedFile = _mapper.Map(updateFileRequest, requestedFile);
            var updatedFile = await _fileRepository.UpdateAsync(requestedFile);
            return _mapper.Map<UpdateFileResponse>(updatedFile);
        }
    }
}
