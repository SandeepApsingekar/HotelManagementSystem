using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.HotelServices
{
    public class LocationService : IService<Location>
    {
        private readonly IRepository<Location> _locationRepository;
        public LocationService(IRepository<Location> locationRepository)
        {
            this._locationRepository = locationRepository;
        }
        public void Create(Location obj)
        {
            _locationRepository.Add(obj);
        }

        public void Delete(Location obj)
        {
            _locationRepository.Delete(obj);
        }

        public IEnumerable<Location> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
              ? _locationRepository.GetAll()
              : _locationRepository.GetAll().Where(c => c.City == name);
        }

        public Location GetById(int id)
        {
            var user = _locationRepository.GetById(id);
            return user;

        }

        public Location GetByName(string name)
        {
            return _locationRepository.GetByName(name);
        }
    }
}
