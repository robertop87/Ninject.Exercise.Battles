namespace Battles
{
    using Battles.UI;

    public class BattleApplication
    {
        private readonly IGuiPresenter guiPresenter;
        private readonly ILogPresenter logPresenter;

        public BattleApplication()
        {
        }

        public BattleApplication(IGuiPresenter guiPresenter, ILogPresenter logPresenter)
        {
            this.guiPresenter = guiPresenter;
            this.logPresenter = logPresenter;
        }

        public virtual void Start()
        {
            this.guiPresenter.StartGame();
        }
    }
}