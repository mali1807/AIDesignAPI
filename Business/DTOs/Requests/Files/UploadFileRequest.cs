using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Files
{
    public class UploadFileRequest
    {
        public IFormFileCollection? Files { get; set; }
    }
}
