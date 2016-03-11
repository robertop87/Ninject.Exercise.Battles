using Battles.Log;

namespace Battles
{
    using System;

    using Battles.UI;

    public class Program
    {
        public static void Main(string[] args)
        {
            int redArmySize = 10;
            int blueArmySize = 15;

            ILogService logService = new LogService();

            IView view = new GuiView();
            IFightEngine fightEngine = new FightEngine(logService);
            IBattleEngine battleEngine = new BattleEngine(fightEngine, logService, redArmySize, blueArmySize);
            IGuiPresenter guiPresenter = new GuiPresenter(view, battleEngine);
            ILogPresenter logPresenter = new LogPresenter(view, logService);

            var application = new BattleApplication(guiPresenter, logPresenter);
            application.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
