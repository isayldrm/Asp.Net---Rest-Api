using Programing.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ProgramingWebApi.Security
{
    public class ApiAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UsersDal userDal = new UsersDal();
            var user = userDal.GetUserByName(userName);
            if (user != null && actionRoles.Contains(user.Role))
            {

            }

            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                    (System.Net.HttpStatusCode.Unauthorized);
            }
            
        }
    }
}