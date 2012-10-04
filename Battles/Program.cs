namespace Battles
{
    using System;

    using Battles.UI;

    public class Program
    {
        public static void Main(string[] args)
        {
            var application = new BattleApplication();
            application.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
