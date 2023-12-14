using Core.DataAccess.Repositories;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Entities.Concrete.Type;

namespace DataAccess.Abstract.Repositories
{
    public interface ITypeRepository:IAsyncRepository<Type>
    {
    }
}
