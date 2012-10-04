namespace Battles
{
    public interface IWeapon
    {
        string Name { get; }

        void Hit(IWarrior target);
    }
}