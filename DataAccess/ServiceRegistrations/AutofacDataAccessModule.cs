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
            builder.RegisterType<DraftRepository>().As<IDraftRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FileRepository>().As<IFileRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DraftImageRepository>().As<IDraftImageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BasketItemRepository>().As<IBasketItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ImageRepository>().As<IImageRepository>().InstancePerLifetimeScope();
        }
    }
}
