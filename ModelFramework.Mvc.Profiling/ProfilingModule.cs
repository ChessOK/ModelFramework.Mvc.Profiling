using Autofac;

using ChessOk.ModelFramework.AsyncCommands;
using ChessOk.ModelFramework.Commands;
using ChessOk.ModelFramework.Web.ViewModels;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public class ProfilingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            DynamicModuleUtility.RegisterModule(typeof(MiniProfilerHttpModule));

            builder.Register(x => new ProfiledCommandDispatcher(x.Resolve<IApplicationBus>()))
                .As<ICommandDispatcher>();
            builder.Register(x => new ProfiledAsyncCommandDispatcher(x.Resolve<IApplicationBus>()))
                .As<IAsyncCommandDispatcher>();
            builder.Register(x => new ProfiledViewModelFactory(x.Resolve<ModelContext>()))
                .As<ViewModelFactory>().InstancePerModelContext();
        }
    }
}
