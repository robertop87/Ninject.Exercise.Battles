namespace Battles.UI
{
    using Log;
    using Misc;

    public class LogPresenter : ILogPresenter
    {
        private readonly IView _view;
        private readonly ILogService _logService;

        public LogPresenter(IView view, ILogService logService)
        {
            _view = view;
            _logService = logService;
        }

        public void Initialize()
        {
            _logService.LogEvent += HandleLogEvent;
        }

        private void HandleLogEvent(object sender, EventArgs<string> e)
        {
            _view.AddText(e.Value);
        }
    }
}
