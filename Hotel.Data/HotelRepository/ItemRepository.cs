using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HotelRepository
{
    public class ItemRepository : GenericRepository<Item>, IRepository<Item>
    {
        public ItemRepository(HotelContext context) : base(context)
        {
        }
    }
}
