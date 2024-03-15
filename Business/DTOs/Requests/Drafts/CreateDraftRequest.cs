using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Drafts
{
    public class CreateDraftRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
