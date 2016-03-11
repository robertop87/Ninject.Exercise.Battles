using Battles.Log;
using Battles.Misc;
using Battles.UI;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Battles
{
    class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFightEngine>().To<FightEngine>();
            Bind<IBattleEngine>().To<BattleEngine>()
                .WithConstructorArgument("redArmySize", Constants.RedArmySize)
                .WithConstructorArgument("blueArmySize", Constants.BlueArmySize);

            Bind<BattleApplication>().ToSelf();

            Bind<IWarrior>().To<Ninja>();
            Bind<IWeapon>().To<Sword>();
            Bind<IWarriorFactory>().ToFactory();

            Bind<IView>().To<LogView>().WhenInjectedInto<LogPresenter>();
            Bind<IView>().To<GuiView>().WhenInjectedInto<GuiPresenter>();

            Bind<ILogPresenter>().To<LogPresenter>().OnActivation(logPresenter => logPresenter.Initialize());
            Bind<IGuiPresenter>().To<GuiPresenter>().OnActivation(guiPresenter => guiPresenter.Initialize());

            Bind<ILogService>().To<LogService>().InSingletonScope();
        }
    }
}

