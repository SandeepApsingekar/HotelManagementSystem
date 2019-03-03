using Hotel.Web.Functions;
using Hotel.Web.Infrastructure;
using Hotel.Web.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Hotel.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                //authCookie.Expires = Convert.ToDateTime(TimeSpan.FromMinutes(1));
                if (authTicket != null)
                {
                    HotelPrincipalSerializeModel serializeModel =
                        JsonConvert.DeserializeObject<HotelPrincipalSerializeModel>(authTicket.UserData);
                    var newUser = new HotelPrincipal(authTicket.Name)
                    {
                        UserId = serializeModel.UserId,
                        FirstName = serializeModel.FirstName,
                        LastName = serializeModel.LastName,
                        Roles = serializeModel.Roles
                    };

                    HttpContext.Current.User = newUser;
                }
            }
        }

        //Error Handling
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                Logger.Log(ex);              
                Server.ClearError();
                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                Response.Redirect(urlHelper.Action("Error", "Error"));
            }
        }
    }
}
