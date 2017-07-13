using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Hotel

        [HandleError]
        public ActionResult Index()
        {
          //  throw new DivideByZeroException();
            if (User != null)
            {
                ViewBag.fullName = User.FirstName + " " + User.LastName;
                return View();
            }
            return View();

        }
    }
}