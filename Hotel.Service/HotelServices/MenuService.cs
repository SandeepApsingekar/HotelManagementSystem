using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.HotelServices
{
    public class MenuService : IService<Menu>
    {
        private readonly IRepository<Menu> _menuRepository;
        public MenuService(IRepository<Menu> menuRepository)
        {
            this._menuRepository = menuRepository;
        }
        public void Create(Menu obj)
        {
            _menuRepository.Add(obj);
        }

        public void Delete(Menu obj)
        {
            _menuRepository.Delete(obj);
        }

        public IEnumerable<Menu> GetAll(string name = null)
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int id)
        {
            var menu = _menuRepository.GetById(id);
            return menu;
        }

        public Menu GetByName(string name)
        {
            return _menuRepository.GetByName(name);
        }
    }
}
