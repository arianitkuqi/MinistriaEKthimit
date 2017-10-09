using MinistriaEKthimit.Messaging.Requests;
using MinistriaEKthimit.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MinistriaEKthimit.UnityConfig;

namespace MinistriaEKthimit.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITest _test;
        private readonly ICityService _cityService;

        public HomeController(ITest test, ICityService cityService)
        {
            _test = test;
            _cityService = cityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            _cityService.GetAllCities();

            return View();
        }


        public ActionResult GetCity(int id,string name)
        {
            var request = new CityRequest(id, name);

            var res = _cityService.GetCityById(request);

            return View(res);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}