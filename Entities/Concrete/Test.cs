using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Test:Entity
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
