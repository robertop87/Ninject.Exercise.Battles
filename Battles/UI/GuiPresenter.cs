namespace Battles.UI
{
    using Battles.Misc;

    public class GuiPresenter : IGuiPresenter
    {
        private readonly IView view;
        private readonly IBattleEngine battle;

        public GuiPresenter(IView guiView, IBattleEngine battleEngine)
        {
            this.view = guiView;
            this.battle = battleEngine;
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