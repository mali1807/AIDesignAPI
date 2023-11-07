using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Adress : Entity
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string AdressDetail { get; set; }
        public string ZipCode { get; set; }  
        
    }
}
