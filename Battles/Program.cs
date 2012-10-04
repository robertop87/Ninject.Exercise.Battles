namespace Battles
{
    using System;

    using Battles.Log;
    using Battles.UI;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int RedArmySize = 20;
            const int BlueArmySize = 23; 

            var logService = new LogService();
            var warriorFactory = new WarriorFactory();
            var logView = new LogView();
            var guiView = new GuiView();
            
            var fightEngine = new FightEngine(logService);
            var battleEngine = new BattleEngine(fightEngine, warriorFactory, logService, RedArmySize, BlueArmySize);
            
            var guiPresenter = new GuiPresenter(guiView, battleEngine);
            guiPresenter.Initialize();
            var logPresenter = new LogPresenter(logView, logService);
            logPresenter.Initialize();

            var application = new BattleApplication(guiPresenter, logPresenter);
            application.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
