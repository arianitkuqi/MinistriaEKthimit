using MinistriaEKthimit.Authorization;
using MinistriaEKthimit.Messaging.Helpers;
using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Messaging.Responses;
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


        [HttpGet]
        public string Index()
        {

            return "It is working";
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
