using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Requests.Products
{
    public class CreateProductRequest
    {
        public string DraftId { get; set;}
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsPrivate { get; set; }
    }
}
