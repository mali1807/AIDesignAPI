using AutoMapper;
using Business.Abstract;
using Business.DTOs.Requests.Drafts;
using Business.DTOs.Responses.Drafts;
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
            var drafts = await _draftRepository.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListDraftResponse>>(drafts);
        }

        public async Task<PermanentDeleteDraftResponse> PermanentDeleteDraftAsync(PermanentDeleteDraftRequest permanentDeleteDraftRequest)
        {
            var selectedDraft = await _draftRepository.GetAsync(t => t.Id == Guid.Parse(permanentDeleteDraftRequest.Id));
            var deletedDraft = await _draftRepository.DeleteAsync(selectedDraft, permanent: true);
            return _mapper.Map<PermanentDeleteDraftResponse>(deletedDraft);
        }

        public async Task<SoftDeleteDraftResponse> SoftDeleteDraftAsync(SoftDeleteDraftRequest softDeleteDraftRequest)
        {
            var selectedDraft = await _draftRepository.GetAsync(t => t.Id == Guid.Parse(softDeleteDraftRequest.Id));
            var deletedDraft = await _draftRepository.DeleteAsync(selectedDraft, permanent: false);
            return _mapper.Map<SoftDeleteDraftResponse>(deletedDraft);
        }

        public async Task<UpdateDraftResponse> UpdateDraftAsync(UpdateDraftRequest updateDraftRequest)
        {
            var requestedDraft = await _draftRepository.GetAsync(t => t.Id == Guid.Parse(updateDraftRequest.Id));
            requestedDraft = _mapper.Map(updateDraftRequest, requestedDraft);
            var updatedDraft = await _draftRepository.UpdateAsync(requestedDraft);
            return _mapper.Map<UpdateDraftResponse>(updatedDraft);
        }
    }
}
