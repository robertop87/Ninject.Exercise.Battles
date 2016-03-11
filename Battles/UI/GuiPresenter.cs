namespace Battles.UI
{
    using Battles.Misc;

    public class GuiPresenter : IGuiPresenter
    {
        private readonly IView view;
        private readonly IBattleEngine battleEngine;

        public GuiPresenter(IView view, IBattleEngine battleEngine)
        {
            this.view = view;
            this.battleEngine = battleEngine;
        }

        public void Initialize()
        {
            this.battleEngine.BattleEvent += this.HandleBattleEvent;
            this.battleEngine.PrepareBattle();
        }

        public void StartGame()
        {
            this.battleEngine.StartBattle();
        }

        private void HandleBattleEvent(object sender, EventArgs<string> e)
        {
            this.view.AddText(e.Value);
        }
    }
}
