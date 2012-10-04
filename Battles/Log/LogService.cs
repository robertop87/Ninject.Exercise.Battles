namespace Battles.Log
{
    using System;

    using Battles.Misc;

    public class LogService : ILogService
    {
        private static ILogService logger;

        public event EventHandler<EventArgs<string>> LogEvent;

        public static ILogService Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = new LogService();
                }

                return logger;
            }
        }

        public void Log(string logEntry)
        {
            if (this.LogEvent != null)
            {
                this.LogEvent(this, new EventArgs<string>(logEntry));
            }
        }
    }
}