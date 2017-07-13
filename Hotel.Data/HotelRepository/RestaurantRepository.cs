using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Hotel.Data.HotelRepository
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly HotelContext _context;
        public RestaurantRepository(HotelContext context)
        {
            this._context = context;
        }
        public void Add(Restaurant entity)
        {
            _context.Restaurant.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<Restaurant, bool>> where)
        {
            IEnumerable<Restaurant> objects = _context.Restaurant.Where<Restaurant>(where).AsEnumerable();
            foreach (Restaurant obj in objects)
            {
                _context.Restaurant.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Delete(Restaurant entity)
        {
            _context.Restaurant.Remove(entity);
        }

        public Restaurant Get(Expression<Func<Restaurant, bool>> where)
        {
            return _context.Restaurant.Where(where).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var a = _context.Restaurant.ToList();
            return a.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurant.Find(id);
        }

        public Restaurant GetByName(string name)
        {
            return _context.Restaurant.FirstOrDefault(d => d.RestaurantName == name);
        }

        public IEnumerable<Restaurant> GetMany(Expression<Func<Restaurant, bool>> where)
        {
            return _context.Restaurant.Where(where).ToList();
        }

        public void Update(Restaurant entity)
        {
            _context.Restaurant.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
