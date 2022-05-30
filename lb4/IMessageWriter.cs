using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb4
{
    internal interface IMessageWriter
    {
        public string Id { get; }
        public void Write();
    }
}
