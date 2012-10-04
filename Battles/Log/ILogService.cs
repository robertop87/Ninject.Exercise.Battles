namespace Battles.Log
{
    using System;

    using Battles.Misc;

    public interface ILogService
    {
        event EventHandler<EventArgs<string>> LogEvent;

        void Log(string logEntry);
    }
}