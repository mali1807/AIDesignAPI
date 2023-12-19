using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.DraftImages
{
    public class CreateDraftImageRequest
    {
        public string ImageId { get; set; }
        public string DraftId { get; set; }
    }
}
