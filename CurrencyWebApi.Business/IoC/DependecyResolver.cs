using Autofac;
using AutoMapper;
using CurrencyWebApi.Business.Services.CurrencyDetailsService;
using CurrencyWebApi.Business.Services.CurrencyService;
using CurrencyWebApi.Domain.Repositories;
using CurrencyWebApi.Infrastructre.Repositories;

namespace CurrencyWebApi.Business.IoC
{
    public class DependecyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyDetailsService>().As<ICurrencyDetailsService>().InstancePerLifetimeScope();

            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyDetailRespository>().As<ICurrencyDetailRepositroy>().InstancePerLifetimeScope();

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<CurrencyWebApi.Business.Mapping.Mapping>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion
        }
    }
}
