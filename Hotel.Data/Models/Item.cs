using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public enum OrderType
    {
        Online, Offline
    }
    public class Item
    {
        public int Id { get; set; }
        public int MenuID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("MenuID")]
        public virtual Menu Menu { get; set; }
    }
}
