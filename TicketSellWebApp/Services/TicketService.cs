using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using TicketSellWebApp.Repositories.cs;

namespace TicketSellWebApp.Services
    {
        public class TicketService : IService<Ticket>
        {
            public List<Ticket> GetList()
            {
                return _iRepositoryClass.GetList().Result;
            }
            public bool Create(Ticket ticket)
            {
                return _iRepositoryClass.Create(ticket).Result;
            }
            public bool Edit(int id, Ticket ticket)
            {
                return _iRepositoryClass.Edit(id, ticket).Result;
            }

            public Ticket FindById(int id)
            {
                return _iRepositoryClass.FindById(id).Result;
            }
            public Ticket FindByInfo(Ticket ticket)
            {
                return _iRepositoryClass.findByInfo(ticket).Result;
            }

            public bool Delete(int id)
            {
                return _iRepositoryClass.Delete(id).Result;
            }
            public void dummy()
            {

            }

            public TicketService(IRepository<Ticket> userRepository)
            {
                this._iRepositoryClass = userRepository;
            }
            private readonly IRepository<Ticket> _iRepositoryClass;
        }
}
