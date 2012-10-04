namespace Battles
{
    using System;

    using Ninject;
    using Ninject.Modules;

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
            return new StandardKernel(module);
        }
    }
}
