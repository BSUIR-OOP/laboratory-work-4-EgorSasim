using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DILibrary
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public object Implementation { get; internal set; }
        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            ImplementationType = implementationType;
        }
    }
}
