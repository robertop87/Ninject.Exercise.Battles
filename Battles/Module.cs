namespace Battles
{
    using Battles.Log;
    using Battles.UI;

    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    public class Module : NinjectModule
    {
        private const int RedArmySize = 20;
        private const int BlueArmySize = 23;

        public override void Load()
        {
            this.Kernel.Bind<ILogService>().To<LogService>().InSingletonScope();
            
            this.Kernel.Bind<IWeapon>().To<Sword>();
            this.Kernel.Bind<IWarrior>().To<Ninja>();
            this.Kernel.Bind<IWarriorFactory>().ToFactory();

            this.Kernel.Bind<IFightEngine>().To<FightEngine>();
            this.Kernel.Bind<IBattleEngine>().To<BattleEngine>()
                .WithConstructorArgument("redArmySize", RedArmySize)
                .WithConstructorArgument("blueArmySize", BlueArmySize);

            this.Kernel.Bind<IView>().To<LogView>().WhenInjectedInto<LogPresenter>();
            this.Kernel.Bind<IView>().To<GuiView>().WhenInjectedInto<GuiPresenter>();

            this.Kernel.Bind<IGuiPresenter>().To<GuiPresenter>()
                .OnActivation(p => p.Initialize());

            this.Kernel.Bind<ILogPresenter>().To<LogPresenter>()
                .OnActivation(p => p.Initialize());

            this.Kernel.Bind<BattleApplication>().ToSelf();
        }
    }
}
