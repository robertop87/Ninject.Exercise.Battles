namespace Battles
{
    using System;

    using Ninject.Extensions.Interception;

    public class MinimalLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Intercepting method "+ invocation.Request.Method.Name);
            invocation.Proceed();
        }
    }
}