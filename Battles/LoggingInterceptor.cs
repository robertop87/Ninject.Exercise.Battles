namespace Battles
{
    using System;

    using Ninject.Extensions.Interception;

    public class LoggingInterceptor : SimpleInterceptor
    {
        protected override void BeforeInvoke(IInvocation invocation)
        {
            LoggingHelper.LogInputParameters(invocation);

            base.BeforeInvoke(invocation);
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            LoggingHelper.LogReturnParameter(invocation);

            base.AfterInvoke(invocation);
        }
    }
}