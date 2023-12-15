using Autofac;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ServiceRegistrations
{
    public class AutofacDataAccessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TypeRepository>().As<ITypeRepository>().InstancePerLifetimeScope();
        }
    }
}
