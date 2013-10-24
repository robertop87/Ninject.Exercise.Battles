namespace Battles
{
    using System;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Parameters;

    public class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = InitializeKernel();

            var warrior = kernel.Get<IWarrior>(
                new TypeMatchingConstructorArgument("Red"),
                new TypeMatchingConstructorArgument(42),
                new TypeMatchingConstructorArgument(new Sword()));
           
            Console.WriteLine(warrior + " with " + warrior.Weapon);

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
