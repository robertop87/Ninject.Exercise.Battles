namespace Battles
{
    public class Sword : IWeapon
    {
        public string Name => GetType().Name;

        public override string ToString()
        {
            return Name;
        }

        public void Hit(IWarrior target)
        {
            target.GetsHit(this);
        }
    }
}
