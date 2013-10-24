namespace Battles
{
    using System;

    using Ninject.Extensions.Interception;
    using Ninject.Extensions.Interception.Attributes;
    using Ninject.Extensions.Interception.Request;

    public class LogAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return new LoggingInterceptor(ConsoleColor.Red);
        }
    }
}