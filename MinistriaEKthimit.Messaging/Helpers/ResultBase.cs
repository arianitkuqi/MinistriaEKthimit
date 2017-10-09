using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Helpers
{
    public class ResultBase
    {
        protected bool _succeded;

        internal bool Succeedded { get { return _succeded; } }

        public string Message { get; set; }

        public IResultModel Model { get; set; }
    }
}
