namespace Battles
{
    using System;

    using Ninject;
    using Ninject.Activation.Strategies;
    using Ninject.Modules;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var kernel = InitializeKernel())
            {
                var application = kernel.Get<BattleApplication>();
                application.Start();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static IKernel InitializeKernel()
        {
            NinjectModule module = new Module();
            
            var kernel = new StandardKernel(module);

            kernel.Components.Add<IActivationStrategy, LoggingActivationStrategy>();

            return kernel;
        }
    }
}
