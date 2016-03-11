namespace Battles.Log
{
    using System;
    using Misc;

    public interface ILogService
    {
        event EventHandler<EventArgs<string>> LogEvent;

        void Log(string logEntry);
    }
}