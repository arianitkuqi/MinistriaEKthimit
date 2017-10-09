using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Helpers
{
    public class OkResult : ResultBase
    {
        public OkResult()
        {
            _succeded = true;
        }
    }
}
