namespace Battles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Log;
    using Misc;

    public class BattleEngine : IBattleEngine
    {
        private readonly int _redArmySize;
        private readonly int _blueArmySize;
        
        private readonly IFightEngine _fightEngine;
        private readonly ILogService _logger;

        private IEnumerable<IWarrior> _redArmy;
        private IEnumerable<IWarrior> _blueArmy;

        private readonly IWarriorFactory _warriorFactory;

        public BattleEngine(IFightEngine fightEngine, ILogService logService, IWarriorFactory warriorFactory, int redArmySize, int blueArmySize)
        {
            _fightEngine = fightEngine;
            _logger = logService;
            _redArmySize = redArmySize;
            _blueArmySize = blueArmySize;
            _warriorFactory = warriorFactory;

            _fightEngine.FightEvent += HandleFightEvent;
        }

        public event EventHandler<EventArgs<string>> BattleEvent;

        public void PrepareBattle()
        {
            Log(Constants.PreparingArmies);

            _redArmy = CreateArmy(Constants.Red, _redArmySize);
            _blueArmy = CreateArmy(Constants.Blue, _blueArmySize);

            Log(Constants.ArmiesReady);
        }

        public void StartBattle()
        {
            Log(Constants.BattleStarts);

            var redFighter = GetNextFighter(_redArmy);
            var blueFighter = GetNextFighter(_blueArmy);

            while (BothSidesHaveFighters(redFighter, blueFighter))
            {
                _fightEngine.FightBetween(redFighter, blueFighter);

                redFighter = GetNextFighter(_redArmy);
                blueFighter = GetNextFighter(_blueArmy);
            }

            Log(Constants.BattleEnds);

            ShowBattleResult();
        }

        private static bool IsArmyDefeated(IEnumerable<IWarrior> army)
        {
            return army.All(warrior => !warrior.Alive);
        }

        private static bool BothSidesHaveFighters(IWarrior redFighter, IWarrior blueFighter)
        {
            return (redFighter != null) && (blueFighter != null);
        }

        private static IWarrior GetNextFighter(IEnumerable<IWarrior> army)
        {
            return army.FirstOrDefault(warrior => warrior.Alive);
        }

        private void HandleFightEvent(object sender, EventArgs<string> e)
        {
            InvokeBattleEvent(e.Value);
        }

        private void InvokeBattleEvent(string message)
        {
            BattleEvent?.Invoke(this, new EventArgs<string>(message));
        }

        private void Log(string text)
        {
            _logger.Log(text);
        }

        private IEnumerable<IWarrior> CreateArmy(string faction, int size)
        {
            var army = new List<IWarrior>();
            for (var i = 1; i <= size; i++)
            {
                var warrior = _warriorFactory.Create(WarriorType.Ninja, faction, i);
                army.Add(warrior);
            }

            return army;
        }

        private void ShowBattleResult()
        {
            var battleResult = string.Format(Constants.WinMessage, IsArmyDefeated(_redArmy) ? Constants.Blue : Constants.Red);
            
            InvokeBattleEvent(battleResult);
            Log(battleResult);
        }
    }
}

