namespace Battles.Misc
{
    using System;

    public class EventArgs<T> : EventArgs
    {
        private readonly T value;

        public EventArgs(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return this.value; }
        }
    }
}
