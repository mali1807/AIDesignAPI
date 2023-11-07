using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Type : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Draft> Drafts { get; set; }
    }
}
