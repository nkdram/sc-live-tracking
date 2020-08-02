using RD.MessageQueue.MessageBus;
using RD.MessageQueue.Models;
using Sitecore.Framework.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RD.MessageQueue.Service
{
    /// <summary>
    /// Service to send Contact Info
    /// </summary>
    public class ContactMessageQueueServiceHandler : IMessageHandler<ContactMessage>, IMessageHandler
    {

        private readonly Microsoft.AspNet.SignalR.IHubContext _messageHub;

        public ContactMessageQueueServiceHandler()
        {
            _messageHub = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ContactMessageQueueMessageHub>();
        }

        /// <summary>
        /// Handles Contact Message and relay message through Hub
        /// </summary>
        /// <param name="contactMessage"></param>
        public Task Handle(ContactMessage message, IMessageReceiveContext receiveContext, IMessageReplyContext replyContext)
        {
            this._messageHub.Clients.All.BroadContacts(message);
            return Task.CompletedTask;
        }

        ///// <summary>
        ///// Handles Contact Message and relay message through Hub
        ///// </summary>
        ///// <param name="contactMessage"></param>
        //public async Task Handle(ContactMessage message, IMessageReceiveContext receiveContext, IMessageReplyContext replyContext)
        //{
        //  await Task.Run(() => { this._messageHub.SendContactData(message); }); 
        //}

    }
}