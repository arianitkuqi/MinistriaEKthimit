using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinistriaEKthimit.Messaging.Helpers;
using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Messaging.Results;

namespace MinistriaEKthimit.Services.Implementation
{
    public class CityService:ServiceBase, ICityService
    {
        public ResponseBase GetAllCities()
        {
            var response = new ResponseBase();
            var result = new CityResult2();

            result.Cites = Factory.Perform.GetAll<CityResult>("usp_City_GetAll");
            result.Id = 1;
            result.Key = "TestKey";

            this.SuccessfulResponse(response, result);
            return response;
        }

        public ResponseBase GetCityById(CityRequest request)
        {
            var response = new ResponseBase();

            var result = Factory.Perform.GetSingle<CityResult>("usp_City_GetById",request);

            this.SuccessfulResponse(response, result);
            return response;
        }

        public ResponseBase GetCityById(int id)
        {
            var response = new ResponseBase();

            var result = Factory.Perform.GetSingle<CityResult>("usp_City_GetById", new { Key = "Id", Value = id });

            this.SuccessfulResponse(response, result);

            return response;
        }
    }
}
