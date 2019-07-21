using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Threading;
using Programing.Dal;
using System.Security.Claims;
using System.Security.Principal;

namespace ProgramingWebApi.Security
{
    public class ApiKeyHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //query den sorgu ile authorization kontrolu
            //var querystring = request.requesturi.parsequerystring();
            //var apikey = querystring["apikey"];

            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
            //Headera authorization bilgilerini girerek veri cekmek
            UsersDal userDal = new UsersDal();
            var user = userDal.GetUserByApiKey(apiKey);
            if (user != null)
            {
                //boyle bir kullanıcı varsa principal objesi oluşturup
                //sistemi kullanan usera pricipal objesini ata
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));
                HttpContext.Current.User = principal;
            }

            else
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}