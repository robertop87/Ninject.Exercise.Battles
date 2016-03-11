using Battles.Misc;

namespace Battles.UI
{
    using System.IO;

    public class LogView : IView
    {
        public LogView()
        {
            File.Delete(Constants.LogFileName);
        }

        public void AddText(string text)
        {
            File.AppendAllLines(Constants.LogFileName, new[] { text });
        }
    }
}
