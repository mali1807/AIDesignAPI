using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Images
{
    public class UploadImageRequest
    {
        public IFormFileCollection? Files { get; set; }
        public bool IsAi { get; set; }
        public bool IsPrivate { get; set; }
    }
}
