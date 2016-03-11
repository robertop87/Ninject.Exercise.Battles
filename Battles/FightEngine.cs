namespace Battles
{
    using System;

    using Log;
    using Misc;

    public class FightEngine : IFightEngine
    {
        private readonly Random _random = new Random();
        private readonly ILogService _logger;

        public FightEngine(ILogService logService)
        {
            _logger = logService;
        }

        public event EventHandler<EventArgs<string>> FightEvent;

        public void FightBetween(IWarrior redFighter, IWarrior blueFighter)
        {
            Log("Fight started");

            bool redAttack = GetRandomBoolean();

            IWarrior attacker;
            IWarrior defender;

            if (redAttack)
            {
                attacker = redFighter;
                defender = blueFighter;
            }
            else
            {
                attacker = blueFighter;
                defender = redFighter;
            }

            attacker.Attacks(defender);

            var message = string.Format("{0} kills {1} with {2}", attacker, defender, attacker.Weapon);
            this.InvokeFightEvent(message);
            this.Log(message);

            this.Log("Fight ended");
        }

        private bool GetRandomBoolean()
        {
            return Convert.ToBoolean(this._random.Next(0, 2));
        }

        private void InvokeFightEvent(string message)
        {
            if (FightEvent != null)
            {
                FightEvent(this, new EventArgs<string>(message));
            }
        }

        private void Log(string text)
        {
            _logger.Log(text);
        }
    }
}
