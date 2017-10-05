using MinistriaEKthimit.Authorization;
using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Services.Contract;
using MinistriaEKthimit.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistriaEKthimit.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ICityService _cityService;
        public HomeController(ICityService cityService)
        {
            _cityService = cityService;
        }


        public string Index()
        {
            var request = new CityRequest {
                //Id = 18
            };


            var response = _cityService.GetCustomCity(request);

            var res = response.Result;

            return "s";
          }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class test:ITest
    {

    }

    public interface ITest
    {

    }
}
