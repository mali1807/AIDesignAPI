using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BasketItem : Entity
    {
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set;}
        public int Quantity { get; set;}
        public virtual Product Product  { get; set; }
        public virtual Basket Basket  { get; set; }


    }
}
