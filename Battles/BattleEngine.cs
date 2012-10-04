namespace Battles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Battles.Log;
    using Battles.Misc;

    public class BattleEngine : IBattleEngine
    {
        private const int RedArmySize = 20;
        private const int BlueArmySize = 23;
        
        private readonly IFightEngine fightEngine;
        private readonly ILogService logger;
        private readonly IWarriorFactory factory;

        private IEnumerable<IWarrior> redArmy;
        private IEnumerable<IWarrior> blueArmy;

        public BattleEngine()
        {
            this.fightEngine = new FightEngine();
            this.logger = LogService.Logger;
            this.factory = new WarriorFactory();

            this.fightEngine.FightEvent += this.HandleFightEvent;
        }

        public event EventHandler<EventArgs<string>> BattleEvent;

        public void PrepareBattle()
        {
            this.Log("Armies are preparing");
            
            this.redArmy = this.CreateArmy("Red", RedArmySize);
            this.blueArmy = this.CreateArmy("Blue", BlueArmySize);
            
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