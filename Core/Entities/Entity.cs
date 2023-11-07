using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Entity
    {
        public Guid Id { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public virtual DateTime UpdatedDate { get; set; } 
        public bool Status { get; set; } 


    }
}
