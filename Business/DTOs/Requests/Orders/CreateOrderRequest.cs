using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Orders
{
    public class CreateOrderRequest
    {
        public string BasketId { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
    }
}
