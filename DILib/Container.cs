using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DILib
{
    // "NOT_CHOOSEN IS FOR FUTURE"
    public class Container
    {
        private List<ServiceDescriptor> serviceDescriptors;
        public Container(List<ServiceDescriptor> serviceDescriptors)
        {
            this.serviceDescriptors = serviceDescriptors;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                var service = serviceDescriptors
               .SingleOrDefault(x => x.ServiceType == serviceType);
            }
            catch (Exception)
            {
                throw new Exception("Too much services");
            }

            var descriptor = serviceDescriptors
               .SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
                throw new Exception("Have no descriptor");

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Don't see abstract class or interface");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
                descriptor.Implementation = implementation;


            return implementation;

        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}

