using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RD.MessageQueue.Models
{
    /// <summary>
    /// Session Event Types -- New User, Update
    /// </summary>
    public enum ContactSessionEventType
    {
        NewSession = 0,
        UpdateSession = 1,
        DeleteSession = 2
    }
}