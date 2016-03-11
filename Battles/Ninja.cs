namespace Battles
{
    public class Ninja : IWarrior
    {
        private readonly int _id;

        public Ninja(string faction, int id, IWeapon weapon)
        {
            Alive = true;
            Weapon = weapon;
            Faction = faction;
            _id = id;
        }

        public IWeapon Weapon { get; }

        public bool Alive { get; private set; }

        public string Faction { get; }

        public string Name => $"{GetType().Name} {_id}";

        public void GetsHit(IWeapon attackWeapon)
        {
            Alive = false;
        }

        public void Attacks(IWarrior target)
        {
            Weapon.Hit(target);
        }

        public override string ToString()
        {
            return $"{Faction} {Name}";
        }
    }
}
