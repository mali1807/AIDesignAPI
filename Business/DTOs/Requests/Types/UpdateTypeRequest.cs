﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Types
{
    public class UpdateTypeRequest
    {
        public string Id { get; set; }
        public string? Name { get; set; }
    }
}
