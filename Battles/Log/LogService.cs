namespace Battles.Log
{
    using System;

    using Misc;

    public class LogService : ILogService
    {
        public event EventHandler<EventArgs<string>> LogEvent;

        public void Log(string logEntry)
        {
            if (LogEvent != null)
            {
                LogEvent(this, new EventArgs<string>(logEntry));
            }
        }
    }
}