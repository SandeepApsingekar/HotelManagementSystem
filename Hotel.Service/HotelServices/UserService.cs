﻿using Hotel.Data.Models;
using Hotel.Data.Repository;
using Hotel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.HotelServices
{
    public class UserService : IService<User>
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }
        public void Create(User user)
        {
            _userRepository.Add(user);
        }

       
        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
              ? _userRepository.GetAll()
              : _userRepository.GetAll().Where(c => c.FirstName == name);
        }

        public User GetByName(string name)
        {
            return _userRepository.GetByName(name);
        }

        public User GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }
    }
}
