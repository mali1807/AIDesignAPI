using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Drafts;
using Business.DTOs.Requests.Types;
using Business.DTOs.Responses.Drafts;
using Business.DTOs.Responses.Types;
using Core.DataAccess.Paging;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DraftManager : IDraftService
    {
        private readonly IDraftRepository _draftRepository;
        private readonly IMapper _mapper;

        public DraftManager(IDraftRepository draftRepository, IMapper mapper)
        {
            _draftRepository = draftRepository;
            _mapper = mapper;
        }

        public async Task<CreateDraftResponse> CreateDraftAsync(CreateDraftRequest createDraftRequest)
        {
            var draft = _mapper.Map<Draft>(createDraftRequest);
            var createdDraft = await _draftRepository.AddAsync(draft);
            return _mapper.Map<CreateDraftResponse>(createdDraft);
        }

        public async Task<IPaginate<GetListDraftResponse>> GetListDraftAsync(PageRequest pageRequest)
        {
            var types = await _draftRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListDraftResponse>>(types);
        }
    }
}
