using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace MinistriaEKthimit.Authorization
{
    public class Authorize
    {
        public static bool check(AuthorizationContext authctx)
        {
            return GetAuthorizations(authctx.HttpContext.User.Identity.Name, authctx.HttpContext.Request.Url.AbsolutePath).Count > 0;
        }

        public static List<string> GetAuthorizations(string userName, string module)
        {

            //Get list of access authorizations for specified module.
            
            return new List<string>(){ };
        }
    }

    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var url = new UrlHelper(filterContext.RequestContext);
            var urlReferer = request.Url.PathAndQuery;

            var signInUrl = url.Action("Index", "SignIn", new { Area = "Account", ReturnUrl = urlReferer });
            var accessDeniedUrl = url.Action("PageAccessDenied", "Error", new { Area = "" });
            
            //if (!request.IsAuthenticated)
            //{
            //    if (request.IsAjaxRequest())
            //    {
            //        filterContext.Result =
            //            new JsonResult
            //            {
            //                Data = new { error = true, signinerror = true, message = "Sign in required", url = signInUrl },
            //                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //            };
            //    }
            //    else
            //    {
            //        filterContext.Result = new RedirectResult(signInUrl);
            //    }

            //}
            //else
            //{
              
                if (!Authorize.check(filterContext))
                {
                    if (request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult
                            {
                                Data =
                                    new
                                    {
                                        error = true,
                                        message = "Access denied"
                                    },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult(accessDeniedUrl);
                    }
                }

            //}

        }
    }




}