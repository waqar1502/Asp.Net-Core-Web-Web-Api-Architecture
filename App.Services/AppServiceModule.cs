using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace App.Services
{
   public class AppServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // builder.RegisterType<CharacterRepository>().As<ICharacterRepository>();

            // REGISTERING TYPES BY CONVENTION
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Factory")) // REGISTERING ALL FACTORIES
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service")) // REGISTERING ALL SERVICES
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
               .Where(t => t.Name.EndsWith("Helper")) // REGISTERING ALL HELPERS
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("IntentHandler")) // REGISTERING ALL HANDLERS
                .AsSelf();

            builder.RegisterAssemblyTypes(assembly)
              .Where(t => t.Name.EndsWith("Handler")) // REGISTERING ALL Handler
              .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
             .Where(t => t.Name.EndsWith("Repository")) // REGISTERING ALL Repository
             .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
             .Where(t => t.Name.EndsWith("Intent")) // REGISTERING ALL Intent
             .AsSelf();
            builder.RegisterAssemblyTypes(assembly)
                        .Where(t => t.Name.EndsWith("Api")) // REGISTERING ALL Intent
                        .AsSelf();
        }
    }
}
