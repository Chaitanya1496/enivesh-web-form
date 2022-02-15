using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace enivesh_web_form.ErrorLog
{
    public class Log
    {
        public void LogMessage(string errorMessage)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(errorMessage, EventLogEntryType.Information);
            }
        }
    }
}