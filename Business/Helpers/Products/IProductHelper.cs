using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.Products
{
    public interface IProductHelper
    {
        public Task<string> DuplicateDraft(string draftId);
    }
}
