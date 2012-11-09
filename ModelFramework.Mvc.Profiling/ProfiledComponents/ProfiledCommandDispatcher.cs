using ChessOk.ModelFramework.Commands;

using StackExchange.Profiling;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public class ProfiledCommandDispatcher : CommandDispatcher
    {
        public ProfiledCommandDispatcher(IApplicationBus bus)
            : base(bus)
        {
        }

        protected override void Handle(CommandBase command)
        {
            var profiler = StackExchange.Profiling.MiniProfiler.Current;

            using (profiler.Step(command.GetType().Name))
            {
                base.Handle(command);
            }
        }
    }
}
