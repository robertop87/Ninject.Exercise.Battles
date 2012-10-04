namespace Battles.Log
{
    using System;

    using Battles.Misc;

    public class LogService : ILogService
    {
        public event EventHandler<EventArgs<string>> LogEvent;

        public void Log(string logEntry)
        {
            if (this.LogEvent != null)
            {
                this.LogEvent(this, new EventArgs<string>(logEntry));
            }
        }
    }
}