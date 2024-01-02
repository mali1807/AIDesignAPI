using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Orders
{
    public class CreateOrderResponse
    {
        public string Id{ get; set; }
        public string BasketId { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
    }
}
