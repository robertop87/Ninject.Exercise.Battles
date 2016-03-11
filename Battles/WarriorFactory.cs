namespace Battles
{
    public class WarriorFactory
    {
        public static IWarrior Create(WarriorType type, string faction, int id)
        {
            switch (type)
            {
                //case WarriorType.Ninja:
                //    return new Ninja(faction, id, new Sword());
                default: return new Ninja(faction, id, new Sword());
            }
        }
    }
}
