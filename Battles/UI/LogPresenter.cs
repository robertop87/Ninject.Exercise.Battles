namespace Battles.UI
{
    using Battles.Log;
    using Battles.Misc;

    public class LogPresenter : ILogPresenter
    {
        private readonly IView view;
        private readonly ILogService logService;

        public LogPresenter()
        {
            this.view = new LogView();
            this.logService = LogService.Logger;
        }

        public void Initialize()
        {
            this.logService.LogEvent += this.HandleLogEvent;
        }

        private void HandleLogEvent(object sender, EventArgs<string> e)
        {
            this.view.AddText(e.Value);
        }
    }
}