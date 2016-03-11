namespace Battles
{
    public class Ninja : IWarrior
    {
        private readonly string faction;
        private readonly int id;

        public Ninja(string faction, int id, IWeapon weapon)
        {
            this.Alive = true;
            this.Weapon = weapon;
            this.faction = faction;
            this.id = id;
        }

        public IWeapon Weapon { get; private set; }

        public bool Alive { get; private set; }

        public string Faction
        {
            get { return this.faction; }
        }

        public string Name
        {
            get { return string.Format("Ninja {0}", this.id); }
        }

        public void GetsHit(IWeapon attackWeapon)
        {
            this.Alive = false;
        }

        public void Attacks(IWarrior target)
        {
            this.Weapon.Hit(target);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Faction, this.Name);
        }
    }
}