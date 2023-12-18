using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : Entity
    {
        public Guid DraftId { get; set; }
        public int LikeCount  { get; set; }
        public string Name  { get; set; }
        public double Price  { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual Draft Draft { get; set; }

    }
}
