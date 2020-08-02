using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Pipelines.Tracking
{
    public class TrackingSessionEnd : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            //if (Tracker.Current != null && Tracker.Current.IsActive && Tracker.Current.Session != null)
            //{
            //    Tracker.Current.Session.IdentifyAs(identificationSource, username);
            //}
        }
    }
}