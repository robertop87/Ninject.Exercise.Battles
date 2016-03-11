using Ninject;

namespace Battles
{
    using System;
    using Misc;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var kernel = new StandardKernel(new AppModule()))
            {
                var application = kernel.Get<BattleApplication>();
                application.Start();
            }

            Console.WriteLine(Constants.PressToExit);
            Console.ReadKey();
        }
    }
}
