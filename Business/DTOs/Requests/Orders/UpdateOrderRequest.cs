using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Orders
{
    public class UpdateOrderRequest
    {
        public string Id { get; set;}
        public string? BasketId { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsCanceled { get; set; }
    }
}
