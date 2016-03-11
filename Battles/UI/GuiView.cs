namespace Battles.UI
{
    using System;

    public class GuiView : IView
    {
        public void AddText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
