using MinistriaEKthimit.Messaging.Helpers;
using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Messaging.Responses;

namespace MinistriaEKthimit.Services.Implementation
{
    public class CityService : ServiceBase, ICityService
    {
        public ResponseBase GetCustomCity(CityRequest request)
        {
            var response = new ResponseBase();
            var result = Factory.Perform.GetSingle<CityResult>("usp_City_GetCustom", request);

            this.SuccessfulResponse(response, result);
            return response;
        }
    }
}
