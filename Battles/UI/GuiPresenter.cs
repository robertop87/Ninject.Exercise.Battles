namespace Battles.UI
{
    using Battles.Misc;

    public class GuiPresenter : IGuiPresenter
    {
        private readonly IView _view;
        private readonly IBattleEngine _battleEngine;

        public GuiPresenter(IView view, IBattleEngine battleEngine)
        {
            _view = view;
            _battleEngine = battleEngine;
        }

        public void Initialize()
        {
            _battleEngine.BattleEvent += HandleBattleEvent;
            _battleEngine.PrepareBattle();
        }

        public void StartGame()
        {
            _battleEngine.StartBattle();
        }

        private void HandleBattleEvent(object sender, EventArgs<string> e)
        {
            _view.AddText(e.Value);
        }
    }
}
