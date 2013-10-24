namespace Battles
{
    using System;
    using System.IO;

    using Ninject.Activation;
    using Ninject.Activation.Strategies;

    public class LoggingActivationStrategy : ActivationStrategy
    {
        private const string FileName = "Activation.txt";

        public LoggingActivationStrategy()
        {
            File.Delete(FileName);
        }

        /// <summary>
        /// Activates the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="reference">The reference.</param>
        public override void Activate( IContext context, InstanceReference reference )
        {
            string implementationTypeName = context.Plan.Type.FullName;

            File.AppendAllText(FileName, "Activate: " + implementationTypeName + Environment.NewLine);

            base.Activate( context, reference );
        }

        /// <summary>
        /// Deactivates the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="reference">The reference.</param>
        public override void Deactivate( IContext context, InstanceReference reference )
        {
            string name = context.Plan.Type.FullName;

            File.AppendAllText(FileName, "Deactivate: " + name + Environment.NewLine);

            base.Deactivate( context, reference );
        }
    }
}