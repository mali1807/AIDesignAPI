﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Interceptors;
using System.Reflection;
using Module = Autofac.Module;
using Business.Helpers.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Helpers.Products;

using Business.Storages.Concrete;
using Business.Storages.Abstract;
using Business.Storages.Azure;


namespace Business.ServiceRegistrations
{
    public class AutofacBusinessModule : Module
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
            builder.RegisterType<RoleManager>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();



            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

            builder.RegisterType<BasketHelper>().As<IBasketHelper>().InstancePerLifetimeScope();
            builder.RegisterType<ProductHelper>().As<IProductHelper>().InstancePerLifetimeScope();


            builder.RegisterType<StorageManager>().As<IStorageService>().InstancePerLifetimeScope();
            builder.RegisterType<AzureStorageManager>().As<IStorage>().InstancePerLifetimeScope();

        }
    }
}
