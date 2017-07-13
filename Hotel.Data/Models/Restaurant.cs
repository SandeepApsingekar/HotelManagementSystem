using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        public string RestaurantImage { get; set; }
        [Required]
        public string RestaurantDescription { get; set; }
        public ICollection<Location> Location { get; set; }
        public virtual User User { get; set; }
    }
}
