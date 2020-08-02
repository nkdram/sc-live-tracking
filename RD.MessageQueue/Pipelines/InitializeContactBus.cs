using Sitecore.Pipelines;
using System;
using Sitecore.Framework.Messaging;
using RD.MessageQueue.MessageBus;

namespace RD.MessageQueue.Pipelines
{
    public class InitializeContactBus
    {
        private readonly IServiceProvider serviceProvider;
        public InitializeContactBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Process(PipelineArgs args)
        {
            this.serviceProvider.StartMessageBus<ContactMessageBus>();
        }
    }
}