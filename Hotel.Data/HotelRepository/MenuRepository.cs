using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.HotelRepository
{
    public class MenuRepository : GenericRepository<Menu>, IRepository<Menu>
    {
        public MenuRepository(HotelContext context) : base(context)
        {
        }
    }
}
