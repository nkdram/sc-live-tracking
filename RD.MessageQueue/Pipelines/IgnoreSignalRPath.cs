using Sitecore;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Pipelines
{
    /// <summary>
    /// Ingore Signal R Path
    /// </summary>
    public class IgnoreSignalRPath : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (args.Url.FilePath.StartsWith("/signalr", StringComparison.OrdinalIgnoreCase))
            {
                args.AbortPipeline();
            }
        }
    }
}