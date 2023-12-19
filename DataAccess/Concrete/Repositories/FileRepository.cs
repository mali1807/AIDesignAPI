using Core.DataAccess.Repositories;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Concrete.File;


namespace DataAccess.Concrete.Repositories
{
    public class FileRepository : EfRepositoryBase<File, SqlDbContext>, IFileRepository
    {
        public FileRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
