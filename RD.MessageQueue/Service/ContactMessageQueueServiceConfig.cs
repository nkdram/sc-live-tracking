using Sitecore.Framework.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Configuration;
using RD.MessageQueue.MessageBus;
using RD.MessageQueue.Models;

namespace RD.MessageQueue.Service
{
    public class ContactMessageQueueServiceConfig : IServicesConfigurator
    {
        /// <summary>
        /// DI registration
        /// </summary>
        /// <param name="serviceCollection"></param>
        public void Configure(IServiceCollection serviceCollection)
        {
            ///Message Queue Handler
            serviceCollection.AddTransient<IMessageHandler<ContactMessage>, ContactMessageQueueServiceHandler>();

            ///Message Queue Service
            //serviceCollection.AddTransient(provider => Factory.CreateObject("rd/messagequeue/service/contactmessagequeueservice", true) as ContactMessageQueueService);
        }
    }
}