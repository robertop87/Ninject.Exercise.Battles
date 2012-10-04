namespace Battles
{
    using System;

    using Battles.Log;
    using Battles.Misc;

    public class FightEngine : IFightEngine
    {
        private readonly Random random = new Random();
        private readonly ILogService logger;

        public FightEngine()
        {
            this.logger = LogService.Logger;
        }

        public event EventHandler<EventArgs<string>> FightEvent;

        public void FightBetween(IWarrior redFighter, IWarrior blueFighter)
        {
            this.Log("Fight started");

            bool redAttack = this.GetRandomBoolean();

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
            return Convert.ToBoolean(this.random.Next(0, 2));
        }

        private void InvokeFightEvent(string message)
        {
            if (this.FightEvent != null)
            {
                this.FightEvent(this, new EventArgs<string>(message));
            }
        }

        private void Log(string text)
        {
            this.logger.Log(text);
        }
    }
}