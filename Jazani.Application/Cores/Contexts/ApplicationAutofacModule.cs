using System.Reflection;
using Autofac;

namespace Jazani.Application.Cores.Contexts
{
	public class ApplicationAutofacModule : Autofac.Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}

