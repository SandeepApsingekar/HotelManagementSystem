using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public enum MenuType
    {
        Breakfast, Lunch, Snacks, Dinner
    } 
    public class Menu
    {    
        public int Id { get; set; }
        public int LocationID { get; set; }
        public MenuType MenuType { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
