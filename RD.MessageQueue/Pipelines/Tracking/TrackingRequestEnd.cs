using RD.MessageQueue.Models;
using Sitecore.Analytics;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Pipelines.Tracking
{
    public class TrackingRequestEnd : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (Tracker.Current != null && Tracker.Current.IsActive && Tracker.Current.Session != null)
            {
                var currentContact = Tracker.Current.Session.Contact;
                var currentInteraction = Tracker.Current.Session.Interaction;
                

                if (currentContact != null && currentInteraction != null)
                {
                    var personalInfo = currentContact.GetFacet<Sitecore.Analytics.XConnect.Facets.IXConnectFacets>("XConnectFacets");

                    var contactMessage = new ContactMessage()
                    {
                        ContactId = currentContact.ContactId.ToString(),
                        //ContactName = $"{personalInfo} {personalInfo.LastName}",
                        CurrentPage = currentInteraction.CurrentPage.Url.ToString(),
                        SiteName = currentInteraction.SiteName,
                        UserAgent = currentInteraction.UserAgent,
                        SessionType = ContactSessionEventType.UpdateSession,
                        IP = currentInteraction.Ip.ToString(),
                        Location = $"{currentInteraction.GeoData.City} , {currentInteraction.GeoData.Country}"
                        
                    };
                    //RD.MessageQueue.Service
                    //var messageService = Sitecore.Configuration.Factory.CreateObject("rd/messagequeue/service/contactmessagequeueservice", true)
                    //as Service.ContactMessageQueueService;


                    Service.ContactMessageQueueService messageService = (Service.ContactMessageQueueService) ServiceLocator.ServiceProvider.GetService(typeof(Service.IContactMessageQueueService));
                    //Relay Message
                    messageService.SendContactMessage(contactMessage);
                }
            }
        }
    }
}