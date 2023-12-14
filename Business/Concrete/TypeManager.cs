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

        public async Task<CreateTypeResponse> CreateTypeAsync(CreateTypeRequest createTypeRequest)
        {
            var type = _mapper.Map<Type>(createTypeRequest);
            var createdType=await _typeRepository.AddAsync(type);
            return _mapper.Map<CreateTypeResponse>(createdType);
        }

        public async Task<IPaginate<GetListTypeResponse>> GetListTypeAsync(PageRequest pageRequest)
        {
            var types=await _typeRepository.GetListAsync(index:pageRequest.PageIndex,size:pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListTypeResponse>>(types);
            
        }
    }
}
