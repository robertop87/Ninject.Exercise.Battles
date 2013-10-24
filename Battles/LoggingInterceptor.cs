namespace Battles
{
    using System;

    using Ninject.Extensions.Interception;

    public class LoggingInterceptor : SimpleInterceptor
    {
        private readonly ConsoleColor color;

        public LoggingInterceptor()
        {
            color = ConsoleColor.Gray;
        }

        public LoggingInterceptor(ConsoleColor color)
        {
            this.color = color;
        }

        protected override void BeforeInvoke(IInvocation invocation)
        {
            LoggingHelper.LogInputParameters(invocation, color);

            base.BeforeInvoke(invocation);
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            LoggingHelper.LogReturnParameter(invocation, color);

            base.AfterInvoke(invocation);
        }
    }
}