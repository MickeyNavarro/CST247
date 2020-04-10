using System;
using System.Web.Mvc;

namespace Activity1_3.Controllers
{
    //define [customauthorization] attribute so it can be declared on any controller or controller method to ensure user is authenticated
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //if user is not authenticated, they will be redirected to the login page
            filterContext.Result = new RedirectResult("/Login"); 
        }
    }
}