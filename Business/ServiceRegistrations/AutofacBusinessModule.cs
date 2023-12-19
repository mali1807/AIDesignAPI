using Autofac;
using Business.Abstract;
using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceRegistrations
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TypeManager>().As<ITypeService>().InstancePerLifetimeScope();
            builder.RegisterType<DraftManager>().As<IDraftService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<FileManager>().As<IFileService>().InstancePerLifetimeScope();
            builder.RegisterType<BasketManager>().As<IBasketService>().InstancePerLifetimeScope();
            builder.RegisterType<BasketItemManager>().As<IBasketItemService>().InstancePerLifetimeScope();
            builder.RegisterType<DraftImageManager>().As<IDraftImageService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderManager>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ImageManager>().As<IImageService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressManager>().As<IAddressService>().InstancePerLifetimeScope();
        }
    }
}
