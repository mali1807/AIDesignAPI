using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.BasketItems
{
    public class UpdateBasketItemRequest
    {
        public string Id { get; set;}
        public string? ProductId { get; set; }
        public string? BasketId { get; set; }
        public int? Quantity { get; set; }
    }
}
