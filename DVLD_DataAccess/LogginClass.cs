using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class LogginClass
    {
        public static void LogEntryToWindowsEventLog(string Entry)
        {
            string EventSource = "DVLDApplication";

            //Define Event Source
            if (!EventLog.SourceExists(EventSource))
            {
                EventLog.CreateEventSource(EventSource, "Application");
            }

            //Write The Entry
            EventLog.WriteEntry(EventSource, Entry);
        }
    }
}
