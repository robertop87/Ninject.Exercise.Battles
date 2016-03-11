namespace Battles
{
    using System;

    using UI;
    using Log;
    using Misc;

    public class Program
    {
        public static void Main(string[] args)
        {
            ILogService logService = new LogService();

            IView view = new GuiView();
            IFightEngine fightEngine = new FightEngine(logService);
            IBattleEngine battleEngine = new BattleEngine(fightEngine, logService,
                Constants.RedArmySize, Constants.BlueArmySize);
            IGuiPresenter guiPresenter = new GuiPresenter(view, battleEngine);
            ILogPresenter logPresenter = new LogPresenter(view, logService);

            var application = new BattleApplication(guiPresenter, logPresenter);
            application.Start();

            Console.WriteLine(Constants.PressToExit);
            Console.ReadKey();
        }
    }
}

