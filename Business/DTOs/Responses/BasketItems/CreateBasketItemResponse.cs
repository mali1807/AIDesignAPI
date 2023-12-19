﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.BasketItems
{
    public class CreateBasketItemResponse
    {
        public string ProductId { get; set; }
        public string BasketId { get; set; }
        public int Quantity { get; set; }
    }
}