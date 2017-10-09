using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MinistriaEKthimit.UI.Infrastructure
{
    public class BaseController:Controller
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


        private ClaimsIdentity CurrentIdentity => HttpContext.User.Identity as ClaimsIdentity;


    }

}