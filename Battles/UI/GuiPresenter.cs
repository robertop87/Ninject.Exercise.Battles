namespace Battles.UI
{
    using Battles.Misc;

    public class GuiPresenter : IGuiPresenter
    {
        private readonly IView view;
        private readonly IBattleEngine battle;

        public GuiPresenter()
        {
            this.view = new GuiView();
            this.battle = new BattleEngine();
        }

        public void Initialize()
        {
            this.battle.BattleEvent += this.HandleBattleEvent;

            this.battle.PrepareBattle();
        }

        public void StartGame()
        {
            this.battle.StartBattle();
        }

        private void HandleBattleEvent(object sender, EventArgs<string> e)
        {
            this.view.AddText(e.Value);
        }
    }
}