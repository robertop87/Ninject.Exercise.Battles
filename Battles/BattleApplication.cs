namespace Battles
{
    using Battles.UI;

    public class BattleApplication
    {
        private readonly IGuiPresenter _guiPresenter;
        private readonly ILogPresenter _logPresenter;

        public BattleApplication(IGuiPresenter guiPresenter, ILogPresenter logPresenter)
        {
            _guiPresenter = guiPresenter;
            _guiPresenter.Initialize();

            _logPresenter = logPresenter;
            _logPresenter.Initialize();
        }

        public void Start()
        {
            this._guiPresenter.StartGame();
        }
    }
}
