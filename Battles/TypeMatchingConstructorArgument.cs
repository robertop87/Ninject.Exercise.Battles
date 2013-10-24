namespace Battles
{
    using System;

    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;

    public class TypeMatchingConstructorArgument : IConstructorArgument
    {
        private readonly object value;

        public TypeMatchingConstructorArgument(object value)
        {
            this.value = value;
        }

        public bool AppliesToTarget(IContext context, ITarget target)
        {
            var type = this.value.GetType();
            var targetType = target.Type;

            return targetType.IsAssignableFrom(type);
        }

        public object GetValue(IContext context, ITarget target)
        {
            return this.value;
        }

        public bool Equals(IParameter other)
        {
            throw new NotImplementedException();
        }

        public string Name { get; private set; }
        public bool ShouldInherit { get; private set; }
    }
}