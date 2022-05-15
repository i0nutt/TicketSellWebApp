using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using TicketSellWebApp.Repositories.cs;

namespace TicketSellWebApp.Services
{
    public class ShowService : IService<Show>
    {
        public bool Create(Show t)
        {
            return _iRepositoryClass.Create(t).Result;
        }

        public bool Delete(int id)
        {
            return _iRepositoryClass.Delete(id).Result;
        }

        public bool Edit(int id, Show t)
        {
            return _iRepositoryClass.Edit(id, t).Result;
        }

        public Show FindById(int id)
        {
            return _iRepositoryClass.FindById(id).Result;
        }

        public Show FindByInfo(Show t)
        {
            throw new NotImplementedException();
        }

        public List<Show> GetList()
        {
            return _iRepositoryClass.GetList().Result;
        }
        public ShowService(IRepository<Show> showRepository)
        {
            this._iRepositoryClass = showRepository;
        }
        private readonly IRepository<Show> _iRepositoryClass;
    }
}
