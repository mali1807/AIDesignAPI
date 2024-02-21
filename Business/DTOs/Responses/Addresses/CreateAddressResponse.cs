using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Responses.Addresses
{
    public class CreateAddressResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
    }
}
