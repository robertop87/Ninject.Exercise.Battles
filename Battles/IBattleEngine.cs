namespace Battles
{
    using System;

    using Misc;

    public interface IBattleEngine
    {
        event EventHandler<EventArgs<string>> BattleEvent; 
        
        void PrepareBattle();
        
        void StartBattle();
    }
}