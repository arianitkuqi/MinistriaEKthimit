using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistriaEKthimit.Messaging.Helpers
{
    public abstract class ServiceBase
    {
        public virtual void SuccessfulResponse(IResponse response, IResultModel resultModel, string message = null)
        {
            response.Result = new OkResult { Model = resultModel };
            if (!string.IsNullOrEmpty(message))
                response.Result.Message = message;
        }
    }
}
