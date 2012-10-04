namespace Battles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Battles.Log;
    using Battles.Misc;

    public class BattleEngine : IBattleEngine
    {
        private readonly int redArmySize;
        private readonly int blueArmySize;
        
        private readonly IFightEngine fightEngine;
        private readonly ILogService logger;
        private readonly IWarriorFactory factory;

        private IEnumerable<IWarrior> redArmy;
        private IEnumerable<IWarrior> blueArmy;

        public BattleEngine(IFightEngine engine, IWarriorFactory warriorFactory, ILogService logger, int redArmySize, int blueArmySize)
        {
            this.fightEngine = engine;
            this.factory = warriorFactory;
            this.logger = logger;
            this.redArmySize = redArmySize;
            this.blueArmySize = blueArmySize;

            this.fightEngine.FightEvent += this.HandleFightEvent;
        }

        public event EventHandler<EventArgs<string>> BattleEvent;

        public void PrepareBattle()
        {
            this.Log("Armies are preparing");
            
            this.redArmy = this.CreateArmy("Red", this.redArmySize);
            this.blueArmy = this.CreateArmy("Blue", this.blueArmySize);
            
            this.Log("Armies are ready to fight");
        }

        public void StartBattle()
        {
            this.Log("Battle started");

            var redFighter = GetNextFighter(this.redArmy);
            var blueFighter = GetNextFighter(this.blueArmy);

            while (BothSidesHaveFighters(redFighter, blueFighter))
            {
                this.fightEngine.FightBetween(redFighter, blueFighter);

                redFighter = GetNextFighter(this.redArmy);
                blueFighter = GetNextFighter(this.blueArmy);
            }

            this.Log("Battle ended");

            this.ShowBattleResult();
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
            if (this.BattleEvent != null)
            {
                this.BattleEvent(this, new EventArgs<string>(message));
            }
        }

        private void Log(string text)
        {
            this.logger.Log(text);
        }

        private IEnumerable<IWarrior> CreateArmy(string faction, int size)
        {
            var army = new List<IWarrior>();
            for (int i = 1; i <= size; i++)
            {
                 army.Add(this.factory.CreateWarrior(faction, i));
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