namespace Battles
{
    using System;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Planning.Bindings.Resolvers;

    public class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = InitializeKernel();

            var application = kernel.Get<BattleApplication>();
            application.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static IKernel InitializeKernel()
        {
            NinjectModule module = new Module();
            var kernel = new StandardKernel(module);

            kernel.Components.Add<IMissingBindingResolver, WeaponMissingBindingResolver>();
            return kernel;
        }
    }
}