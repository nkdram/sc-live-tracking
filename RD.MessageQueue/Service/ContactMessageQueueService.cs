using RD.MessageQueue.MessageBus;
using RD.MessageQueue.Models;
using Sitecore.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Service
{
    /// <summary>
    /// Service to send Contact Info
    /// </summary>
    public class ContactMessageQueueService : IContactMessageQueueService
    {
        private readonly IMessageBus<ContactMessageBus> messageBus;

        public ContactMessageQueueService(IMessageBus<ContactMessageBus> messageBus)
        {
            this.messageBus = messageBus;
        }

        /// <summary>
        /// Relays Contact Message
        /// </summary>
        /// <param name="contactMessage">Contact Message Data</param>
        public virtual void SendContactMessage(ContactMessage contactMessage)
        {
            this.messageBus.SendAsync(contactMessage);
        }

        
    }
}