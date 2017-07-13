using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Hotel.Web.Infrastructure
{
    public class HotelPrincipal : IPrincipal
    {
        public bool IsInRole(string role)
        {
            return Roles.Any(r => r.Contains(role));
        }
        public HotelPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }
        public IIdentity Identity { get; private set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string[] Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}