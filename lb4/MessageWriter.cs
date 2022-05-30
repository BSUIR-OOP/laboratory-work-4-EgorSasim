﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb4
{
    internal class MessageWriter : IMessageWriter
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public void Write() => Console.WriteLine($"{Id}");
    }
}
