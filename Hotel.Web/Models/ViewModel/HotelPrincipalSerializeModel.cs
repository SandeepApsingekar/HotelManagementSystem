using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Web.Models.ViewModel
{
    public class HotelPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}