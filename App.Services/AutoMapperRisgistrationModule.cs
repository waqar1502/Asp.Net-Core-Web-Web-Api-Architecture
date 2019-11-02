using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace App.Services
{
   public class AutoMapperRisgistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            }))
                .AsSelf()
                .AutoActivate()
                .SingleInstance();

            builder.Register(c =>
            {
                // these are the changed lines
                var scope = c.Resolve<ILifetimeScope>();
                return new Mapper(c.Resolve<MapperConfiguration>(), scope.Resolve);
            })
                .As<IMapper>()
                .SingleInstance();
        }
    }
}
