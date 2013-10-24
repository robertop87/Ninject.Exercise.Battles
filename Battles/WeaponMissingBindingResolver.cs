namespace Battles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Activation;
    using Ninject.Activation.Providers;
    using Ninject.Components;
    using Ninject.Infrastructure;
    using Ninject.Planning.Bindings;
    using Ninject.Planning.Bindings.Resolvers;

    public class WeaponMissingBindingResolver : NinjectComponent, IMissingBindingResolver
    {
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            var service = request.Service;
            if (!IsIWeapon(service))
            {
                return Enumerable.Empty<IBinding>();
            }

            var creationCallback = StandardProvider.GetCreationCallback(typeof(Dagger));

            return new[]
            {
                new Binding(service) { ProviderCallback = creationCallback }
            };
        }

        private static bool IsIWeapon(Type service)
        {
            return service == typeof(IWeapon);
        }
    }
}