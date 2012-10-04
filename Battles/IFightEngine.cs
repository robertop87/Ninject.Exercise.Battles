namespace Battles
{
    using System;

    using Battles.Misc;

    public interface IFightEngine
    {
        event EventHandler<EventArgs<string>> FightEvent;

        void FightBetween(IWarrior redFighter, IWarrior blueFighter);
    }
}