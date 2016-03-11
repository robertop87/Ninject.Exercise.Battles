namespace Battles
{
    using UI;

    public class BattleApplication
    {
        private readonly IGuiPresenter _guiPresenter;
        private readonly ILogPresenter _logPresenter;

        public BattleApplication(IGuiPresenter guiPresenter, ILogPresenter logPresenter)
        {
            _guiPresenter = guiPresenter;
            _logPresenter = logPresenter;
        }

        public void Start()
        {
            _guiPresenter.StartGame();
        }
    }
}
