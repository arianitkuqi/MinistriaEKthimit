using MinistriaEKthimit.Models.Messaging.Requests;
using MinistriaEKthimit.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistriaEKthimit.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }


        public string Index()
        {
            return _personService.GetPerson(new PersonRequest(1, "test")).Company;
  
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
