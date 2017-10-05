using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace MinistriaEKthimit.Controllers.ApiControllers
{
    public class GetUsersController : ApiController
    {
        private readonly ICityService _cityService;

        public GetUsersController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/GetUsers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetUsers/5
        public IHttpActionResult Get(int id)
        {
            var request = new CityRequest
            {
                //Id = 18
            };
            var response = _cityService.GetCustomCity(request);

            return Json(response);
        }

        // POST: api/GetUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetUsers/5
        public void Delete(int id)
        {
        }
    }
}
