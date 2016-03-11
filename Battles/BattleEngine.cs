namespace Battles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Battles.Log;
    using Battles.Misc;

    public class BattleEngine : IBattleEngine
    {
        private readonly int RedArmySize;
        private readonly int BlueArmySize;
        
        private readonly IFightEngine fightEngine;
        private readonly ILogService logger;

        private IEnumerable<IWarrior> redArmy;
        private IEnumerable<IWarrior> blueArmy;

        public BattleEngine(IFightEngine fightEngine, ILogService logService, int redArmySize, int blueArmySize)
        {
            this.fightEngine = fightEngine;
            this.logger = logService;
            this.RedArmySize = redArmySize;
            this.BlueArmySize = blueArmySize;

            this.fightEngine.FightEvent += this.HandleFightEvent;
        }

        public event EventHandler<EventArgs<string>> BattleEvent;

        public void PrepareBattle()
        {
            Log("Armies are preparing");

            redArmy = CreateArmy("Red", RedArmySize);
            blueArmy = CreateArmy("Blue", BlueArmySize);

            Log("Armies are ready to fight");
        }

        public void StartBattle()
        {
            Log("Battle started");

            var redFighter = GetNextFighter(redArmy);
            var blueFighter = GetNextFighter(blueArmy);

            while (BothSidesHaveFighters(redFighter, blueFighter))
            {
                fightEngine.FightBetween(redFighter, blueFighter);

                redFighter = GetNextFighter(redArmy);
                blueFighter = GetNextFighter(blueArmy);
            }

            Log("Battle ended");

            ShowBattleResult();
        }

        private static bool IsArmyDefeated(IEnumerable<IWarrior> army)
        {
            return army.All(warrior => !warrior.Alive);
        }

        private static bool BothSidesHaveFighters(IWarrior redFighter, IWarrior blueFighter)
        {
            return redFighter != null && blueFighter != null;
        }

        private static IWarrior GetNextFighter(IEnumerable<IWarrior> army)
        {
            return army.FirstOrDefault(warrior => warrior.Alive);
        }

        private void HandleFightEvent(object sender, EventArgs<string> e)
        {
            this.InvokeBattleEvent(e.Value);
        }

        private void InvokeBattleEvent(string message)
        {
            if (BattleEvent != null)
            {
                BattleEvent(this, new EventArgs<string>(message));
            }
        }

        private void Log(string text)
        {
            logger.Log(text);
        }

        private IEnumerable<IWarrior> CreateArmy(string faction, int size)
        {
            var army = new List<IWarrior>();
            for (int i = 1; i <= size; i++)
            {
                var warrior = WarriorFactory.Create(WarriorType.Ninja, faction, i);
                army.Add(warrior);
            }

            return army;
        }

        private void ShowBattleResult()
        {
            var battleResult = string.Format("{0} won", IsArmyDefeated(this.redArmy) ? "Blue" : "Red");
            
            this.InvokeBattleEvent(battleResult);
            this.Log(battleResult);
        }
    }
}
