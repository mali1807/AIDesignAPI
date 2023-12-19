using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Images
{
    public class CreateImageRequest
    {
        public bool IsAi { get; set; }
        public bool IsPrivate { get; set; }
    }
}
