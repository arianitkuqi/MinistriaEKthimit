﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Helpers
{
    public interface IResponse
    {
        bool Succeedded { get; }
        ResultBase Result { get; set; }
    }
}
