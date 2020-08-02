using Microsoft.AspNet.SignalR;
using Owin;
using Sitecore.Annotations;
using Sitecore.Diagnostics;
using Sitecore.Owin.Pipelines.Initialize;


namespace RD.MessageQueue.Pipelines
{
    public class ContentMesssageOwinInitialize : InitializeProcessor
    {
        public override void Process([NotNull] InitializeArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            args.App.MapSignalR("/signalr", new HubConfiguration() { });
        }
    }
}