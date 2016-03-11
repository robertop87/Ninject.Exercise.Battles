using Battles.Log;
using Battles.Misc;
using Battles.UI;
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
            Bind<WarriorFactory>().ToSelf().InSingletonScope();

            Bind<IView>().To<LogView>().WhenInjectedInto<LogPresenter>();
            Bind<IView>().To<GuiView>().WhenInjectedInto<GuiPresenter>();

            Bind<ILogPresenter>().To<LogPresenter>().OnActivation(p => p.Initialize());
            Bind<IGuiPresenter>().To<GuiPresenter>().OnActivation(p => p.Initialize());

            Bind<ILogService>().To<LogService>().InSingletonScope();
        }
    }
}
