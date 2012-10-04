namespace Battles
{
    class WarriorFactory : IWarriorFactory
    {
        public IWarrior CreateWarrior(string faction, int id)
        {
            return new Ninja(faction, id, new Sword());
        }
    }
}