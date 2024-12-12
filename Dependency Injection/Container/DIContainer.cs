namespace Dependency_Injection.Container
{
    public enum ServiceLifetime
    {
        Transient,
        Singleton
    }


    public class DiContainer
    {
        private readonly Dictionary<Type, Func<object>> _transientServices = new();
        private readonly Dictionary<Type, object> _singletonServices = new();

        public void Register<TService, TImplementation>(ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation), lifetime);
        }

        private void Register(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            if (lifetime == ServiceLifetime.Singleton)
            {
                _singletonServices[serviceType] = CreateInstance(implementationType);
            }
            else
            {
                _transientServices[serviceType] = () => CreateInstance(implementationType);
            }
        }

        public TService Resolve<TService>()
        {
            return (TService)Resolve(typeof(TService));
        }

        private object Resolve(Type serviceType)
        {
            if (_singletonServices.TryGetValue(serviceType, out var service))
            {
                return service;
            }

            if (_transientServices.TryGetValue(serviceType, out var transientService))
            {
                return transientService();
            }

            throw new InvalidOperationException($"Service of type {serviceType} not registered");
        }

        private object CreateInstance(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().FirstOrDefault();
            
            if (constructor == null)
                throw new InvalidOperationException($"No public constructor found for type {implementationType}");

            var parameters = constructor.GetParameters().Select(param => Resolve(param.ParameterType)).ToArray();

            return Activator.CreateInstance(implementationType, parameters) ?? throw new InvalidOperationException();
        }
    }
}
