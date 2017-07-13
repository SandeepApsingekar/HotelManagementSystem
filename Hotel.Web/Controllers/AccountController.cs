using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Web.Functions;
using Hotel.Web.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Web.Controllers
{
    public class AccountController : Controller
    {
        HotelContext db = new HotelContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                Role r = db.Roles.Where(z => z.RoleName == "General").FirstOrDefault();
                UserRoleInfo userRole = new UserRoleInfo();
                userRole.RoleId = r.RoleId;
                userRole.UserId = user.UserId;
                db.UserInfo.Add(user);
                db.UserRoleInfo.Add(userRole);
                db.SaveChanges();
                string a = user.Username;
                string subject = "Your Verification Link";
                var sb = new StringBuilder("<body style='margin: 0px;'>");
                // Add your link
                sb.AppendFormat("<div>Please click <a href='http://localhost:56942/Account/LoginToActive?Username={0}'>Click here</a></div>", a);
                // Close the body element
                sb.Append("</body>");
                // Get your e-mail contents using the ToString() method
                var body = sb.ToString();
                //string body = "Please click <a href=\"http://localhost:56942/Account/LoginToActive?Username=\"" + a + "> here</a> to redirect to your home page!";
                SendEmail s = new SendEmail();
                s.SendMail(a,subject ,body);
                return View("Success");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var user = db.UserInfo.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                    if (user != null)
                    {
                        if (user.IsActive == true)
                        {
                            var userRoles = user.Roles.Select(r => r.RoleName).ToArray();
                            var serializeModel = new HotelPrincipalSerializeModel
                            {
                                UserId = user.UserId,
                                FirstName = user.FirstMidName,
                                LastName = user.LastName,
                                Roles = userRoles
                            };

                            var userData = JsonConvert.SerializeObject(serializeModel);
                            var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now,
                                DateTime.Now.AddMinutes(15), false, userData);
                            var encTicket = FormsAuthentication.Encrypt(authTicket);
                            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            Response.Cookies.Add(faCookie);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please, check you email and activate your account!");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Username or password is incorrect!')</script>");
                        //ModelState.AddModelError("", "Incorrect username and/or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username and/or password");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        public ActionResult LoginToActive(string Username)
        {
            UserInfo user = db.UserInfo.Where(z => z.Username == Username).FirstOrDefault();
            user.IsActive = true;
            db.SaveChanges();
            if (user != null)
            {
                var userRoles = user.Roles.Select(r => r.RoleName).ToArray();
                var serializeModel = new HotelPrincipalSerializeModel
                {
                    UserId = user.UserId,
                    FirstName = user.FirstMidName,
                    LastName = user.LastName,
                    Roles = userRoles
                };

                var userData = JsonConvert.SerializeObject(serializeModel);
                var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now,
                    DateTime.Now.AddMinutes(15), false, userData);
                var encTicket = FormsAuthentication.Encrypt(authTicket);
                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}