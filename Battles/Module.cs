namespace Battles
{
    using System;

    using Battles.UI;

    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Interception;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using Ninject.Modules;
    
    public class Module : NinjectModule
    {
        private const int RedArmySize = 1;
        private const int BlueArmySize = 1;

        public override void Load()
        {
            // * OPTIONS ************************************************************************************************
            // **********************************************************************************************************

            this.Kernel.Bind<IWeapon>().To<Sword>();
            
            // **********************************************************************************************************

            //var actionInterceptor = new ActionInterceptor(
            //                invocation =>
            //                {
            //                    Console.WriteLine("Intercepting by action interceptor " + invocation.Request.Method.Name);
            //                    invocation.Proceed();
            //                });

            //this.Kernel.Bind<IWeapon>().To<Sword>().Intercept().With(actionInterceptor);
            
            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>().Intercept().With<MinimalLoggingInterceptor>();

            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>().Intercept().With<LoggingInterceptor>();

            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>();
            //this.Kernel.InterceptAround<Sword>(
            //                weapon => weapon.Hit(null),
            //                invocation => Console.WriteLine("Before invoking " + invocation.Request.Method.Name),
            //                invocation => Console.WriteLine("After invoking " + invocation.Request.Method.Name));
            
            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>();
            //this.Kernel.Intercept(ctx => true).With<LoggingInterceptor>();
            
            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>();
            //this.Kernel.Intercept(ctx => true).With<LoggingInterceptor>();

            //this.Kernel.InterceptAround<Sword>(
            //                weapon => weapon.Hit(null),
            //                invocation => LoggingHelper.LogInputParameters(invocation, ConsoleColor.Red),
            //                invocation => LoggingHelper.LogReturnParameter(invocation, ConsoleColor.Red));

            // **********************************************************************************************************

            //this.Kernel.Bind<IWeapon>().To<Sword>();
            //this.Kernel.Intercept(ctx => true).With<LoggingInterceptor>();

            // enable LogAttribute on Sword.Hit(...)
            
            // **********************************************************************************************************

            this.Kernel.Bind<IWarrior>().To<Ninja>();

            this.Kernel.Bind(
                x =>
                x.FromThisAssembly().SelectAllClasses().Where(t => t.Name.EndsWith("Service"))
                    .BindAllInterfaces()
                    .Configure(b => b.InSingletonScope()));

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
