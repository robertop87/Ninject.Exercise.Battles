namespace Battles
{
    using UI;

    public class BattleApplication
    {
        private readonly IGuiPresenter _guiPresenter;

        public BattleApplication(IGuiPresenter guiPresenter, ILogPresenter logPresenter)
        {
            _guiPresenter = guiPresenter;
        }

        public void Start()
        {
            _guiPresenter.StartGame();
        }
    }
}
