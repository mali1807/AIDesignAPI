using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class File : Entity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public virtual Image Image { get; set; }
    }
}
