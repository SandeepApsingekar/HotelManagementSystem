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
    public class UserRepository : IRepository<User>
    {
        private readonly HotelContext _context;
        public UserRepository(HotelContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<User, bool>> where)
        {
            IEnumerable<User> objects = _context.User.Where<User>(where).AsEnumerable();
            foreach (User obj in objects)
                _context.User.Remove(obj);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.User.Remove(entity);
        }

        public User Get(Expression<Func<User, bool>> where)
        {
            return _context.User.Where(where).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            var a = _context.User.ToList();
            return a.ToList();
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public User GetByName(string name)
        {
            return _context.User.FirstOrDefault(d => d.FirstName== name);
        }

        public IEnumerable<User> GetMany(Expression<Func<User, bool>> where)
        {
            return _context.User.Where(where).ToList();
        }

        public void Update(User entity)
        {
            _context.User.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
