using Core.DataAccess.Repositories;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = Entities.Concrete.Product;

namespace DataAccess.Concrete.Repositories
{
    public class ProductRepository : EfRepositoryBase<Product, SqlDbContext>, IProductRepository
    {
        public ProductRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
