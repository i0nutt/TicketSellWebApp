using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using TicketSellWebApp.Repositories;
using TicketSellWebApp.Repositories.cs;

namespace TicketSellWebApp.Services
    {
        public class TicketService : ITicketService<Ticket>
        {
            public List<Ticket> GetList()
            {
                return _iRepositoryClass.GetList().Result;
            }
            public bool Create(Ticket ticket)
            {
                if (ValidateCreate(ticket))
                    return _iRepositoryClass.Create(ticket).Result;
                else
                    return false;
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
            public List<Ticket> FindByShow(int ShowNumber)
            {
                Ticket t = new Ticket();
                t.ShowNumber = ShowNumber;
                return _iRepositoryClass.FindByInfo1(t).Result;
            }

            public bool Delete(int id)
            {
                return _iRepositoryClass.Delete(id).Result;
            }
            
            private bool ValidateCreate(Ticket T)
            {
                if(_iRepositoryClass.countByInfo(T.ShowNumber).Result <
                _iShowRepositoryClass.FindById(T.ShowNumber).Result.NumberOfTickets)
                {
                    if (_iRepositoryClass.findCopy(T).Result == null)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            public TicketService(ITicketRepository<Ticket> userRepository, IRepository<Show> _iShowRepositoryClass)
            {
                this._iRepositoryClass = userRepository;
                this._iShowRepositoryClass = _iShowRepositoryClass;
            }
            private readonly ITicketRepository<Ticket> _iRepositoryClass;
        private readonly IRepository<Show> _iShowRepositoryClass;
    }
}
