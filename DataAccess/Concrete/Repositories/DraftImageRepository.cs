﻿using Core.DataAccess.Repositories;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class DraftImageRepository : EfRepositoryBase<DraftImage, SqlDbContext>, IDraftImageRepository
    {
        public DraftImageRepository(SqlDbContext context) : base(context)
        {
        }
    }
}
