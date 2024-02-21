﻿using Core.Entities;
using Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address : Entity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
        public virtual User User { get; set; }
    }
}
