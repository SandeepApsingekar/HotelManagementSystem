using Hotel.Data.Models;
using Hotel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.HotelServices
{
    public class ItemService : IService<Item>
    {
        private readonly IRepository<Item> _itemRepository;
        public ItemService(IRepository<Item> itemRepository)
        {
            this._itemRepository = itemRepository;
        }
        public void Create(Item obj)
        {
            _itemRepository.Add(obj);
        }

        public void Delete(Item obj)
        {
            _itemRepository.Delete(obj);
        }

        public IEnumerable<Item> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
             ? _itemRepository.GetAll()
             : _itemRepository.GetAll().Where(c => c.ItemName == name);
        }

        public Item GetById(int id)
        {
            var user = _itemRepository.GetById(id);
            return user;
        }

        public Item GetByName(string name)
        {
            return _itemRepository.GetByName(name);
        }
    }
}
