namespace Battles
{
    public interface IWarrior
    {
        string Faction { get; }

        string Name { get; }

        bool Alive { get; }

        IWeapon Weapon { get; }

        void Attacks(IWarrior target);

        void GetsHit(IWeapon attackWeapon);
    }
}