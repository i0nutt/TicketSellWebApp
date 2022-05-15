using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;
using Microsoft.EntityFrameworkCore;
using TicketSellWebApp.Repositories.cs;

namespace TicketSellWebApp.Services
{
    public class UserService : IService<User>
    {
        public List<User> GetList()
        {
            return _iRepositoryClass.GetList().Result;
        }
        public bool Create(User user)
        {
            return _iRepositoryClass.Create(user).Result;
        }
        public bool Edit(int id, User user)
        {
            return _iRepositoryClass.Edit(id, user).Result;
        }

        public User FindById(int id)
        {
            return _iRepositoryClass.FindById(id).Result;
        }
        public User FindByInfo(User user)
        {
            return _iRepositoryClass.findByInfo(user).Result;
        }

        public bool Delete(int id)
        {
            return _iRepositoryClass.Delete(id).Result;
        }
        public void dummy()
        {

        }

        public UserService(IRepository<User> userRepository)
        {
            this._iRepositoryClass = userRepository;
        }
        private readonly IRepository<User> _iRepositoryClass;
    }
}
