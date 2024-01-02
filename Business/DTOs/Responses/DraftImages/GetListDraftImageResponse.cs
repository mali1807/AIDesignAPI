using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.DraftImages
{
    public class GetListDraftImageResponse
    {
        public string Id { get; set; }
        public string ImageId { get; set; }
        public string DraftId { get; set; }
    }
}
