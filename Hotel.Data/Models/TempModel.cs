using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class TempModel
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string Email { get; set; }
        public string RestaurantName { get; set; }
        public bool IsApproved { get; set; }
        public bool SentEmail { get; set; }
        public DateTime SentEmailDate { get; set; }

    }
}
