namespace Battles
{
    public class Dagger : IWeapon
    {
        public string Name
        {
            get { return "Dagger"; }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void Hit(IWarrior target)
        {
            target.GetsHit(this);
        }
    }
}