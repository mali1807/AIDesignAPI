﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Files
{
    public class CreateFileResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
    }
}
