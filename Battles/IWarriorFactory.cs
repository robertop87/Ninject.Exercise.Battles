namespace Battles
{
    public interface IWarriorFactory
    {
        IWarrior Create(WarriorType type, string faction, int id);
    }
}
