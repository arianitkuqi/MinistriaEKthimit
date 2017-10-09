using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinistriaEKthimit.Messaging.Helpers;
using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Messaging.Responses;

namespace MinistriaEKthimit.Services.Fake
{
    public class FakeCityService :ServiceBase, ICityService
    {
        public ResponseBase GetCustomCity(CityRequest request)
        {
            var fakeResponse = new ResponseBase();
            var result = new CityResult { Name = "Prishtina" };

            this.SuccessfulResponse(fakeResponse, result);
            return fakeResponse;

        }
    }
}
