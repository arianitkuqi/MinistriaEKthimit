using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Helpers
{
    public class ResponseBase : IResponse
    {
        public bool Succeedded { get { return Result.Succeedded; } }

        public ResultBase Result { get; set; }
    }
}
