using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.HotelServices
{
    public class RestaurantService : IService<Restaurant>
    {
        private readonly IRepository<Restaurant> _restaurantRepository;
        public RestaurantService(IRepository<Restaurant> restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }
        public void Create(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public void Delete(Restaurant restaurant)
        {
            _restaurantRepository.Delete(restaurant);
        }

        public IEnumerable<Restaurant> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
              ? _restaurantRepository.GetAll()
              : _restaurantRepository.GetAll().Where(c => c.RestaurantName == name);
        }

        public Restaurant GetById(int id)
        {
            var restaurant = _restaurantRepository.GetById(id);
            return restaurant;
        }


        public Restaurant GetByName(string name)
        {
            return _restaurantRepository.GetByName(name);
        }
    }
}
