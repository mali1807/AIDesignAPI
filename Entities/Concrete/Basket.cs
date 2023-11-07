using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Basket : Entity
    {
        public Guid UserId { get; set; }
        public int TotalPrice { get; set; }
        public int TotalProduct { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

    }
}
