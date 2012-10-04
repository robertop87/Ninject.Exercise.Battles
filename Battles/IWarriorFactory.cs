namespace Battles
{
    public interface IWarriorFactory
    {
        IWarrior CreateWarrior(string faction, int id);
    }
}