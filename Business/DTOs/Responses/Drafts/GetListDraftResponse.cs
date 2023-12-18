using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Drafts
{
    public class GetListDraftResponse
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool IsPrivate { get; set; }
    }
}
