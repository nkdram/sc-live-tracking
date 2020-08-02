using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Models
{
    /// <summary>
    /// A simple Contact Information Model
    /// </summary>
    public class ContactMessage
    {
        public ContactSessionEventType SessionType { get; set; }

        public string ContactId { get; set; }

        public string ContactName { get; set; }

        public string UserAgent { get; set; }

        public string CurrentPage { get; set; }

        public string SiteName { get; set; }

        public string DeviceName { get; set; }

        public string Location { get; set; }

        public string IP { get; set; }
    }
}