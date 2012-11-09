using System;

using ChessOk.ModelFramework.Web;
using ChessOk.ModelFramework.Web.ViewModels;

using StackExchange.Profiling;

using Profiler = StackExchange.Profiling.MiniProfiler;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public class ProfiledViewModelFactory : ViewModelFactory
    {
        public ProfiledViewModelFactory(ModelContext context)
            : base(context)
        {
        }

        public override TViewModel Create<TViewModel>(Action<TViewModel> initialization)
        {
            using (Profiler.Current.Step("Create " + typeof(TViewModel).Name))
            {
                return base.Create<TViewModel>(initialization);
            }
        }

        public override void Initialize(object viewModel)
        {
            using (Profiler.Current.Step("Initialize " + viewModel.GetType().Name))
            {
                base.Initialize(viewModel);
            }
        }
    }
}
