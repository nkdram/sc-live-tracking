using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RD.MessageQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Service
{
    /// <summary>
    /// Hub that relays Contacts to all clients
    /// </summary>
    [HubName("ContactMessage")]
    public class ContactMessageQueueMessageHub : Hub
    {
        public void SendContactData(ContactMessage contactMessage)
        {
            this.Clients.All.BroadContacts(contactMessage);
        }
    }
}