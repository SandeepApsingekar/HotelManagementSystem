using Hotel.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Controllers
{
    [AuthAttribute(Roles = "Admin,General")]
    public class BaseController : Controller
    {
        protected virtual new HotelPrincipal User
        {
            get { return HttpContext.User as HotelPrincipal; }
        }
    }
}