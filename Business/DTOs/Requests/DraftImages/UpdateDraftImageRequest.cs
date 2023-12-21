using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.DraftImages
{
    public class UpdateDraftImageRequest
    {
        public string Id { get; set;}
        public string? ImageId { get; set; }
        public string? DraftId { get; set; }
    }
}
