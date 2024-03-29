﻿using Core.Entities;
using Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Draft : Entity
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public Guid? TypeId { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public bool IsCompleted { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DraftImage> DraftImages { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
