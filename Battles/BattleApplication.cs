namespace Battles
{
    using Battles.UI;

    public class BattleApplication
    {
        private readonly IGuiPresenter guiPresenter;
        private readonly ILogPresenter logPresenter;

        public BattleApplication()
        {
            this.guiPresenter = new GuiPresenter();
            this.guiPresenter.Initialize();

            this.logPresenter = new LogPresenter();
            this.logPresenter.Initialize();
        }

        public void Start()
        {
            this.guiPresenter.StartGame();
        }
    }
}