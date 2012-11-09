using System;
using System.Web;

using StackExchange.Profiling;

namespace ChessOk.ModelFramework.Mvc.Profiling
{
    public class MiniProfilerHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            MiniProfiler.Settings.ExcludeStackTraceSnippetFromSqlTimings = true;

            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        public void Dispose()
        {
        }

        private static void OnBeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;

            if (context.Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        private static void OnEndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop();
        }
    }
}
