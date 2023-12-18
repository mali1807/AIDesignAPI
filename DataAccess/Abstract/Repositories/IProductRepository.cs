using Core.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = Entities.Concrete.Product;


namespace DataAccess.Abstract.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
