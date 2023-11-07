using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DraftImage : Entity
    {
        public Guid ImageId {get; set;}
        public Guid DraftId { get; set;}
        public virtual Draft Draft { get; set; }
        public virtual Image Image  { get; set; }

    }
}
