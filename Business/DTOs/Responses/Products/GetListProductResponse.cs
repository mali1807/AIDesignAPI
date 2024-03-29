﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Products
{
    public class GetListProductResponse
    {
        public string Id { get; set; }
        public string DraftId { get; set; }
        public int LikeCount { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsPrivate { get; set; }
    }
}
