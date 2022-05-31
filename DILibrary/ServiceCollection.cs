using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DILibrary
{
    public class ServiceCollection
    {
        private List<ServiceDescriptor> serviceDescriptors = new List<ServiceDescriptor>();

        public void AddSingleton<TService, TImplementation>() => 
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));

        public void AddTransient<TService, TImplementation>() => 
            serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));

        public Container GenerateContainer() => new Container(serviceDescriptors);
    }
}
