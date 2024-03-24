using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Images
{
    public class SoftDeleteImageResponse
    {
        public string Id { get; set; }
        public string FileId { get; set; }
        public bool IsAi { get; set; }
        public bool IsPrivate { get; set; }
    }
}
