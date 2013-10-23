namespace Battles
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Ninject.Extensions.Interception;

    public static class LoggingHelper
    {
        public static void LogInputParameters(IInvocation invocation, ConsoleColor foregroundColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;

            LogInputParameters(invocation);

            Console.ForegroundColor = defaultColor;
        }

        public static void LogInputParameters(IInvocation invocation)
        {
            ParameterInfo[] parameterInfos = invocation.Request.Method.GetParameters();
            object[] parameterValues = invocation.Request.Arguments;

            if (!parameterInfos.Any())
            {
                Console.WriteLine(invocation.Request.Method.Name + "() invoked");
                return;
            }

            Console.WriteLine(invocation.Request.Method.Name + "(...) invoked with:");

            for (int index = 0; index < parameterInfos.Length; index++)
            {
                var parameterInfo = parameterInfos[index];
                var parameterValue = parameterValues[index];

                LogParameterNameAndValue(parameterInfo, parameterValue);
            }
        }

        public static void LogReturnParameter(IInvocation invocation, ConsoleColor foregroundColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            
            LogReturnParameter(invocation);

            Console.ForegroundColor = defaultColor;
        }

        public static void LogReturnParameter(IInvocation invocation)
        {
            ParameterInfo returnParameterInfo = invocation.Request.Method.ReturnParameter;
            object returnValue = invocation.ReturnValue;

            if (returnParameterInfo.ParameterType == typeof(void))
            {
                Console.WriteLine(invocation.Request.Method.Name + "() returns void");
                return;
            }

            Console.WriteLine(invocation.Request.Method.Name + "(...) returns with:");
            LogParameterValue(returnValue);
        }

        private static void LogParameterNameAndValue(ParameterInfo parameterInfo, object value)
        {
            Console.WriteLine("   Parameter  name: " + parameterInfo.Name);
            Console.WriteLine("   Parameter value: " + value);
        }

        private static void LogParameterValue(object value)
        {
            Console.WriteLine("   Parameter value: " + value);
        }
    }
}