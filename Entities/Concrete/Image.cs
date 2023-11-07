using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image : Entity
    {
        public Guid FileId { get; set; }
        public bool IsAi { get; set; }
        public bool IsPrivate { get; set; }
        public virtual File File { get; set; }
        public virtual ICollection<DraftImage> DraftImages { get; set; }
    }
}
