namespace Battles.UI
{
    using System.IO;

    public class LogView : IView
    {
        private const string Logfile = "Battle.log";

        public LogView()
        {
            File.Delete(Logfile);
        }

        public void AddText(string text)
        {
            File.AppendAllLines(Logfile, new[] { text });
        }
    }
}
