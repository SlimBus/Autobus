﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimBus.Abstractions
{
    public interface ITransportBuilder
    {
        BaseTransport Build();
    }
}