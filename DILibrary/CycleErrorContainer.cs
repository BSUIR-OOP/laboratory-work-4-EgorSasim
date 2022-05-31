using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DILibrary
{
    internal class CycleErrorContainer
    {
        private readonly string servicesNamespace;
        public CycleErrorContainer(string servicesNamespace)
        {
            this.servicesNamespace = servicesNamespace;
        }
        public string CheckForCycleDependency()
        {

            var serviceDependenceContainer = new Dictionary<string, List<string>>();


            var services = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => String.Equals(t.Namespace, servicesNamespace, StringComparison.Ordinal))
                .ToArray();

            foreach (var service in services)
            {

                var ctors = service.GetConstructors();
                var ctorMain = ctors[0];

                List<string> parametersType = new List<string>();

                foreach (var param in ctorMain.GetParameters())
                {
                    var parameterType = param.ParameterType.Name;
                    parametersType.Add(parameterType);
                }
                serviceDependenceContainer.Add(nameof(service), parametersType);
            }

            var cycles = serviceDependenceContainer.FindCycles();

            if (cycles.Count != 0)
            {
                return "Cyclic Error";
            }
            else
                return string.Empty;


        }
    }
}
