using Autofac;
using UNAProject.Core.Interfaces;
using UNAProject.Core.Services;

namespace UNAProject.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
