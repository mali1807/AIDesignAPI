using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Baskets
{
    public class GetListBasketResponse
    {
        public string Id { get; set; }
        public double TotalPrice { get; set; }
        public int TotalProduct { get; set; }
        public bool IsActive { get; set; }
    }
}
