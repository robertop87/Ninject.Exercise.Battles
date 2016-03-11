namespace Battles
{
    using System;

    using Misc;

    public interface IFightEngine
    {
        event EventHandler<EventArgs<string>> FightEvent;

        void FightBetween(IWarrior redFighter, IWarrior blueFighter);
    }
}