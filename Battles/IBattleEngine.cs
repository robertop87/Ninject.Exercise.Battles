namespace Battles
{
    using System;

    using Battles.Misc;

    public interface IBattleEngine
    {
        event EventHandler<EventArgs<string>> BattleEvent; 
        
        void PrepareBattle();
        
        void StartBattle();
    }
}