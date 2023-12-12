﻿using Core.DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Repositories
{
    public interface ITestRepository:IRepository<Test>
    {
    }
}
