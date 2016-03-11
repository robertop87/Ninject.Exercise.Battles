namespace Battles
{
    using System;

    using Log;
    using Misc;

    public class FightEngine : IFightEngine
    {
        private readonly Random _random;
        private readonly ILogService _logger;

        public FightEngine(ILogService logService)
        {
            _logger = logService;
            _random = new Random();
        }

        public event EventHandler<EventArgs<string>> FightEvent;

        public void FightBetween(IWarrior redFighter, IWarrior blueFighter)
        {
            Log(Constants.FightStarts);

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

            var message = string.Format(Constants.AttackMessage, attacker, defender, attacker.Weapon);
            InvokeFightEvent(message);
            Log(message);

            Log(Constants.FightEnds);
        }

        private bool GetRandomBoolean()
        {
            return Convert.ToBoolean(_random.Next(0, 2));
        }

        private void InvokeFightEvent(string message)
        {
            FightEvent?.Invoke(this, new EventArgs<string>(message));
        }

        private void Log(string text)
        {
            _logger.Log(text);
        }
    }
}
