using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Services
{
    internal static class Factory
    {
        public static FactoryAdapter.FactoryAdapter Perform = FactoryAdapter.FactoryAdapter.Initialize("connectionString here");
    }
}
