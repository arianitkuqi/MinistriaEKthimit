﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistriaEKthimit.Controllers
{
    public class HomeController : Controller
    {
        ITest tt;

        public HomeController(ITest t)
        {
            tt = t;
        }
        public ActionResult Index()
        {
            return View();
  
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
