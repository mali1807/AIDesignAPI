using DataAccess.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.Products
{
    public class ProductHelper : IProductHelper
    {
        private readonly IDraftRepository _draftRepository;

        public ProductHelper(IDraftRepository draftRepository)
        {
            _draftRepository = draftRepository;
        }

        public async Task<string> DuplicateDraft(string draftId)
        {
            //Todo nullcheck
            var draft=await  _draftRepository.GetAsync(d => d.Id == Guid.Parse(draftId));
            draft.Id = Guid.Empty;
            draft.IsCompleted = true;
            var addedDraft=await _draftRepository.AddAsync(draft);
            return addedDraft.Id.ToString();
        }
    }
}
