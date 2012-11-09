using ChessOk.ModelFramework.AsyncCommands;

using StackExchange.Profiling;

using Profiler = StackExchange.Profiling.MiniProfiler;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public class ProfiledAsyncCommandDispatcher : AsyncCommandDispatcher
    {
        public ProfiledAsyncCommandDispatcher(IApplicationBus bus)
            : base(bus)
        {
        }

        protected override void Handle(AsyncCommand asyncCommand)
        {
            using (Profiler.Current.Step(string.Format("Async {0}", asyncCommand.Command.GetType().Name)))
                base.Handle(asyncCommand);
        }
    }
}
