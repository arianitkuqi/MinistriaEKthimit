﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using MinistriaEKthimit.Authorization;

namespace MinistriaEKthimit.Controllers
{
    public class BaseController : Controller
    {

        public string CurrentUserName
        {
            get
            {
                return HttpContext.User.Identity.Name;
            }
        }

        public string CurrentUserGID
        {
            get
            {
                return CurrentIdentity.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }
        }


        public bool checkAuthorization(string action) => Authorize.Check( new AuthorizationContext(HttpContext);


        private ClaimsIdentity CurrentIdentity
        {
            get
            {
                return HttpContext.User.Identity as ClaimsIdentity;
            }
        }

        
    }
}