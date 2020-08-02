using RD.MessageQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Service
{
    /// <summary>
    /// Contact Message Service Interface
    /// </summary>
    public interface IContactMessageQueueService
    {
        /// <summary>
        /// Relays Contact messsages
        /// </summary>
        /// <param name="contactMessage"></param>
         void SendContactMessage(ContactMessage contactMessage);

       
    }
}