namespace Battles
{
    public class Sword : IWeapon
    {
        public string Name
        {
            get { return "Sword"; }
        }

        public override string ToString()
        {
            return this.Name;
        }

        //[Log]
        public void Hit(IWarrior target)
        {
            target.GetsHit(this);
        }
    }
}