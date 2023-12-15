using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Types;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace Business.Concrete
{
    public class TypeManager : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public TypeManager(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }
        //Todo NullCheck eklenecek
        public async Task<CreateTypeResponse> CreateTypeAsync(CreateTypeRequest createTypeRequest)
        {
            var type = _mapper.Map<Type>(createTypeRequest);
            var createdType=await _typeRepository.AddAsync(type);
            return _mapper.Map<CreateTypeResponse>(createdType);
        }

        public async Task<PermanentDeleteTypeResponse> PermanentDeleteTypeAsync(PermanentDeleteTypeRequest permanentDeleteTypeRequest)
        {
            var selectedType = await _typeRepository
                .GetAsync(t => t.Id == Guid.Parse(permanentDeleteTypeRequest.Id));
            var deletedType = await _typeRepository.DeleteAsync(selectedType, permanent:true);
            return _mapper.Map<PermanentDeleteTypeResponse>(deletedType);
        }

        public async Task<IPaginate<GetListTypeResponse>> GetListTypeAsync(PageRequest pageRequest)
        {
            var types=await _typeRepository.GetListAsync(index:pageRequest.PageIndex,size:pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListTypeResponse>>(types);
            
        }

        public async Task<SoftDeleteTypeResponse> SoftDeleteTypeAsync(SoftDeleteTypeRequest softDeleteTypeRequest)
        {
            var selectedType = await _typeRepository
               .GetAsync(t => t.Id == Guid.Parse(softDeleteTypeRequest.Id));
            var hidedType = await _typeRepository.DeleteAsync(selectedType, permanent: false);
            return _mapper.Map<SoftDeleteTypeResponse>(hidedType);
        }

        public async Task<UpdateTypeResponse> UpdateTypeAsync(UpdateTypeRequest updateTypeRequest)
        {
            var requestedType = await _typeRepository.GetAsync(t => t.Id == Guid.Parse(updateTypeRequest.Id));
            requestedType = _mapper.Map(updateTypeRequest, requestedType);
            var updatedType = await _typeRepository.UpdateAsync(requestedType);
            return _mapper.Map<UpdateTypeResponse>(updatedType);
        }
    }
}
