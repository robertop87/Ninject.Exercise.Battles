namespace Battles
{
    using Battles.UI;

    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    
    public class Module : NinjectModule
    {
        private const int RedArmySize = 20;
        private const int BlueArmySize = 23;

        public override void Load()
        {
            this.Kernel.Bind(
                x =>
                x.FromThisAssembly().SelectAllClasses().Where(t => t.Name.EndsWith("Service"))
                    .BindAllInterfaces()
                    .Configure(b => b.InSingletonScope()));

            this.Kernel.Bind<IWeapon>().To<Sword>();
            this.Kernel.Bind<IWarrior>().To<Ninja>();

            this.Kernel.Bind(
                x => 
                x.FromThisAssembly().SelectAllInterfaces().Where(t => t.Name.EndsWith("Factory"))
                    .BindToFactory());

            this.Kernel.Bind(
                x =>
                x.FromThisAssembly().SelectAllClasses().Where(t => t.Name.EndsWith("Engine"))
                    .BindAllInterfaces()
                    .Configure(b => b.InTransientScope())
                    .ConfigureFor<BattleEngine>(b => b.InSingletonScope()
                    .WithConstructorArgument("redArmySize", RedArmySize)
                    .WithConstructorArgument("blueArmySize", BlueArmySize)));

            this.Kernel.Bind(
               x =>
               x.FromThisAssembly().SelectAllClasses().InheritedFrom<IView>()
                   .BindAllInterfaces()
                   .Configure((b, c) => b.When(r => r.Target.Member.DeclaringType.Name == c.Name.Replace("View", "Presenter"))));

            this.Kernel.Bind(
                x =>
                x.FromThisAssembly().SelectAllClasses().InheritedFrom<IPresenter>()
                    .BindAllInterfaces()
                    .Configure(b => b.OnActivation<IPresenter>(p => p.Initialize())));

            this.Kernel.Bind<BattleApplication>().ToSelf();
        }
    }
}
