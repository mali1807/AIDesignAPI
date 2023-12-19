using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Baskets
{
    public class CreateBasketRequest
    {
        public int TotalPrice { get; set; }
        public int TotalProduct { get; set; }
        public bool IsActive { get; set; }
    }
}
