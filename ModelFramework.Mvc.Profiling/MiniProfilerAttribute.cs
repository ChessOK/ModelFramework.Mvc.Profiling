using System;
using System.Web.Mvc;

using StackExchange.Profiling;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public sealed class MiniProfilerAttribute : ActionFilterAttribute
    {
        private IDisposable _actionExecutingProfilerStep;
        private IDisposable _resultExecutingProfilerStep;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var profiler = MiniProfiler.Current;
            _actionExecutingProfilerStep = profiler.Step(String.Format(
                "{0}.{1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_actionExecutingProfilerStep != null)
            {
                _actionExecutingProfilerStep.Dispose();
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var profiler = StackExchange.Profiling.MiniProfiler.Current;
            _resultExecutingProfilerStep = profiler.Step(filterContext.Result.GetType().Name);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (_resultExecutingProfilerStep != null)
            {
                _resultExecutingProfilerStep.Dispose();
            }
        }
    }
}
